#include "sys.h"		    
#include "rs485.h"	 
#include "delay.h"

//////////////////////////////////////////////////////////////////////////////////	 

//RS485���� ����	   
									  
//////////////////////////////////////////////////////////////////////////////////


#ifdef EN_USART3_RX   	//���ʹ���˽���


//���ջ����� 	
u8 RS485A_RX_BUF[RS485_REC_LEN];  	//���ջ���,���64���ֽ�.
//���յ������ݳ���
u8 RS485A_RX_CNT=0;   		  	  
u8 RS485A_begin=0;	                //RS485 1��ͷ��Ǹ�λ
u8 RS485A_end=0;                    //RS485 1��β��Ǹ�λ
u8 RS485A_overflow=0;               //RS485 1�����Ǹ�λ 
void USART3_IRQHandler(void)
{
	u8 res;	    
 
 	if(USART_GetITStatus(USART3, USART_IT_RXNE) != RESET) //���յ�����
	{	 
	 			 
		res =USART_ReceiveData(USART3); 	//��ȡ���յ�������
		if((res==0x55)&&(RS485A_begin==0))             //���յ��˰�ͷ0x55
				{
				RS485A_RX_CNT=0;
				RS485A_begin=1;
				}

		if((RS485A_RX_CNT<RS485_REC_LEN)&&(RS485A_begin==1))
		{
			RS485A_RX_BUF[RS485A_RX_CNT]=res;		//��¼���յ���ֵ
			RS485A_RX_CNT++;						//������������1 
		}
		if((res==0xaa)&&(RS485A_RX_CNT<RS485_REC_LEN)&&(RS485A_begin==1))  //���յ��˰�β0xaa
		{	
		  RS485A_end=1;
		  RS485A_begin=0;
		}
		/*	if(RS485_RX_CNT>(RS485_REC_LEN))
			{
		  RS485_end=1;
		  RS485_begin=0;
		  RS485_overflow=1;
		 }
		  */ 
	}  											 
} 
#endif										 
//��ʼ��IO ����3
//pclk1:PCLK1ʱ��Ƶ��(Mhz)
//bound:������	  
void RS485A_Init(u32 bound)
{  
    GPIO_InitTypeDef GPIO_InitStructure;
  	USART_InitTypeDef USART_InitStructure;
 	NVIC_InitTypeDef NVIC_InitStructure;
 
	RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB|RCC_APB2Periph_AFIO, ENABLE);//ʹ��GPIOCʱ��
	//GPIO_PinRemapConfig(GPIO_PartialRemap_USART3  , ENABLE);//���ʹ��Ĭ�ϵĹ��ܣ��ǾͲ�����ӳ����
	RCC_APB1PeriphClockCmd(RCC_APB1Periph_USART3,ENABLE);//ʹ��USART3ʱ��
	
	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_8;				 //PC12�˿�����
 	GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 		 //�������
 	GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
 	GPIO_Init(GPIOB, &GPIO_InitStructure);


	GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;                       //PC10 
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;     //����������� 
    GPIO_Init(GPIOB, &GPIO_InitStructure);                             

    //RX��ʼ��
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_11;                             //PC11 
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;                  //�������� 

	RCC_APB1PeriphResetCmd(RCC_APB1Periph_USART3,ENABLE);//��λ����3
	RCC_APB1PeriphResetCmd(RCC_APB1Periph_USART3,DISABLE);//ֹͣ��λ
 
	
 #ifdef EN_USART3_RX		  	//���ʹ���˽���
	USART_InitStructure.USART_BaudRate = bound;//һ������Ϊ9600;
	USART_InitStructure.USART_WordLength = USART_WordLength_8b;//8λ���ݳ���
	USART_InitStructure.USART_StopBits = USART_StopBits_1;//һ��ֹͣλ
	USART_InitStructure.USART_Parity = USART_Parity_No;///��żУ��λ
	USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;//��Ӳ������������
	USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;//�շ�ģʽ

    USART_Init(USART3, &USART_InitStructure); ; //��ʼ������
  
	NVIC_InitStructure.NVIC_IRQChannel = USART3_IRQn; //ʹ�ܴ���3�ж�
	NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 3; //��ռ���ȼ�2��
	NVIC_InitStructure.NVIC_IRQChannelSubPriority = 2; //�����ȼ�2��
	NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE; //ʹ���ⲿ�ж�ͨ��
	NVIC_Init(&NVIC_InitStructure); //����NVIC_InitStruct��ָ���Ĳ�����ʼ������NVIC�Ĵ���
 
	//USART_ITConfig(USART3,USART_IT_TXE,ENABLE);  //ʹ�ܷ����ж�
    USART_ITConfig(USART3, USART_IT_RXNE, ENABLE);//���������ж�
   
    USART_Cmd(USART3, ENABLE);                    //ʹ�ܴ��� 

 #endif

 RS485A_TX_EN=0;			//Ĭ��Ϊ����ģʽ
 
}

//RS485A����len���ֽ�.
//buf:�������׵�ַ
//len:���͵��ֽ���(Ϊ�˺ͱ�����Ľ���ƥ��,���ｨ�鲻Ҫ����64���ֽ�)
void RS485A_Send_Data(u8 *buf,u8 len)
{
	u8 t;
	RS485A_TX_EN=1;			//����Ϊ����ģʽ
	delay_ms(5);			//ʹ����ʱ����ֹ���뷢�ʹ���
  	for(t=0;t<len;t++)		//ѭ����������
	{		   
		while(USART_GetFlagStatus(USART3, USART_FLAG_TC) == RESET);	  
		USART_SendData(USART3,buf[t]);
	}	 
 
	while(USART_GetFlagStatus(USART3, USART_FLAG_TC) == RESET);		
	RS485A_RX_CNT=0;	  
	RS485A_TX_EN=0;				//����Ϊ����ģʽ	
}


//RS485A����len���ֽ�.
//buf:�������׵�ַ
//len:���͵��ֽ���(Ϊ�˺ͱ�����Ľ���ƥ��,���ｨ�鲻Ҫ����64���ֽ�)
void RS485A_Perfect_Send_Data(u8 *buf,u8 len)
{
	u8 t;
	u8 HEAD;
	RS485A_TX_EN=1;			//����Ϊ����ģʽ
	delay_ms(5);			//ʹ����ʱ����ֹ���뷢�ʹ���
	HEAD=0X55;				//��ͷ
	buf[len]=0xaa;			//��β
	while(USART_GetFlagStatus(USART3, USART_FLAG_TC) == RESET);
	USART_SendData(USART3,HEAD);
  	for(t=0;t<len+1;t++)	//ѭ���������ݣ�
	{		   
		while(USART_GetFlagStatus(USART3, USART_FLAG_TC) == RESET);	  
		USART_SendData(USART3,buf[t]);
	}	 
 
	while(USART_GetFlagStatus(USART3, USART_FLAG_TC) == RESET);		
	RS485A_RX_CNT=0;	  
	RS485A_TX_EN=0;			 //����Ϊ����ģʽ
	delay_ms(5);			 //ʹ����ʱ����ֹ������մ���	
}

//RS485A��ѯ���յ�������
//buf:���ջ����׵�ַ
//len:���������ݳ���
void RS485A_Receive_Data(u8 *buf,u8 *len)
{
	u8 rxlen=RS485A_RX_CNT;
	u8 i=0;
	*len=0;				//Ĭ��Ϊ0
	delay_ms(10);		//�ȴ�10ms,��������10msû�н��յ�һ������,����Ϊ���ս���
	if(rxlen==RS485A_RX_CNT&&rxlen)//���յ�������,�ҽ��������
	{
		for(i=0;i<rxlen;i++)
		{
			buf[i]=RS485A_RX_BUF[i];	
		}		
		*len=RS485A_RX_CNT;	//��¼�������ݳ���
		RS485A_RX_CNT=0;		//����
	}
}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////
#ifdef EN_UART4_RX   	//���ʹ���˽���

//���ջ����� 	
u8 RS485B_RX_BUF[RS485_REC_LEN];  	//���ջ���,���64���ֽ�.
//���յ������ݳ���
u8 RS485B_RX_CNT=0;   		  	  
u8 RS485B_begin=0;	                //RS485 2��ͷ��Ǹ�λ
u8 RS485B_end=0;                    //RS485 2��β��Ǹ�λ
u8 RS485B_overflow=0;               //RS4852�����Ǹ�λ 
void UART4_IRQHandler(void)
{
	u8 res;	    
 
 	if(USART_GetITStatus(UART4, USART_IT_RXNE) != RESET) //���յ�����
	{	 
	 			 
		res =USART_ReceiveData(UART4); 	//��ȡ���յ�������
		if((res==0x55)&&(RS485B_begin==0))             //���յ��˰�ͷ0x55
				{
				RS485B_RX_CNT=0;
				RS485B_begin=1;
				}

		if((RS485B_RX_CNT<RS485_REC_LEN)&&(RS485B_begin==1))
		{
			RS485B_RX_BUF[RS485B_RX_CNT]=res;		//��¼���յ���ֵ
			RS485B_RX_CNT++;						//������������1 
		}
		if((res==0xaa)&&(RS485B_RX_CNT<RS485_REC_LEN)&&(RS485B_begin==1))  //���յ��˰�β0xaa
		{	
		  RS485B_end=1;
		  RS485B_begin=0;
		}
		/*	if(RS485_RX_CNT>(RS485_REC_LEN))
			{
		  RS485_end=1;
		  RS485_begin=0;
		  RS485_overflow=1;
		 }
		  */ 
	}  											 
} 
#endif


void RS485B_Init(u32 bound)
{ 
    GPIO_InitTypeDef GPIO_InitStructure;
  	USART_InitTypeDef USART_InitStructure;
 	NVIC_InitTypeDef NVIC_InitStructure;
//ʹ��ʱ��
    RCC_APB1PeriphClockCmd(RCC_APB1Periph_UART4, ENABLE);
    RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);
//PC12�˿�����
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_12;				 //PC12�˿�����
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 		 //�������
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_Init(GPIOC, &GPIO_InitStructure);
//���ý��չܽ�PC11
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_11;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
    GPIO_Init(GPIOC, &GPIO_InitStructure);
//���÷��͹ܽ�PC10
    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;
    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
    GPIO_Init(GPIOC, &GPIO_InitStructure);

    RCC_APB1PeriphResetCmd(RCC_APB1Periph_UART4,ENABLE);//��λ����4
	RCC_APB1PeriphResetCmd(RCC_APB1Periph_UART4,DISABLE);//ֹͣ��λ


 #ifdef EN_USART3_RX		  	//���ʹ���˽���
//�����ʡ��ֳ���ֹͣλ����żУ��λ��Ӳ�������ơ��첽����ΪĬ�ϣ������������ã�
    USART_InitStructure.USART_BaudRate = bound;
    USART_InitStructure.USART_WordLength = USART_WordLength_8b;
    USART_InitStructure.USART_StopBits = USART_StopBits_1;
    USART_InitStructure.USART_Parity = USART_Parity_No;
    USART_InitStructure.USART_HardwareFlowControl =
    USART_HardwareFlowControl_None;
    USART_InitStructure.USART_Mode = USART_Mode_Rx | USART_Mode_Tx;
    USART_Init(UART4, &USART_InitStructure);
	//�ж����ȼ�
    NVIC_InitStructure.NVIC_IRQChannel = UART4_IRQn;
    NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 3;
    NVIC_InitStructure.NVIC_IRQChannelSubPriority = 3;
    NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
	NVIC_Init(&NVIC_InitStructure); //����NVIC_InitStruct��ָ���Ĳ�����ʼ������NVIC�Ĵ���


    USART_ITConfig(UART4, USART_IT_RXNE, ENABLE);

    USART_Cmd(UART4, ENABLE);

  #endif

 RS485B_TX_EN=0;			//Ĭ��Ϊ����ģʽ
}
//RS485B����len���ֽ�.
//buf:�������׵�ַ
//len:���͵��ֽ���(Ϊ�˺ͱ�����Ľ���ƥ��,���ｨ�鲻Ҫ����64���ֽ�)
void RS485B_Send_Data(u8 *buf,u8 len)
{
	u8 t;
	RS485B_TX_EN=1;			//����Ϊ����ģʽ
	delay_ms(5);			//ʹ����ʱ����ֹ���뷢�ʹ���
  	for(t=0;t<len;t++)		//ѭ����������
	{		   
		while(USART_GetFlagStatus(UART4, USART_FLAG_TC) == RESET);	  
		USART_SendData(UART4,buf[t]);
	}	 
 
	while(USART_GetFlagStatus(UART4, USART_FLAG_TC) == RESET);		
	RS485B_RX_CNT=0;	  
	RS485B_TX_EN=0;				//����Ϊ����ģʽ	
}


//RS485B����len���ֽ�.
//buf:�������׵�ַ
//len:���͵��ֽ���(Ϊ�˺ͱ�����Ľ���ƥ��,���ｨ�鲻Ҫ����64���ֽ�)
void RS485B_Perfect_Send_Data(u8 *buf,u8 len)
{
	u8 t;
	u8 HEAD;
	RS485B_TX_EN=1;			//����Ϊ����ģʽ
	delay_ms(5);			//ʹ����ʱ����ֹ���뷢�ʹ���
	HEAD=0X55;				//��ͷ
	buf[len]=0xaa;			//��β
	while(USART_GetFlagStatus(UART4, USART_FLAG_TC) == RESET);
	USART_SendData(UART4,HEAD);
  	for(t=0;t<len+1;t++)	//ѭ���������ݣ�
	{		   
		while(USART_GetFlagStatus(UART4, USART_FLAG_TC) == RESET);	  
		USART_SendData(UART4,buf[t]);
	}	 
 
	while(USART_GetFlagStatus(UART4, USART_FLAG_TC) == RESET);		
	RS485B_RX_CNT=0;	  
	RS485B_TX_EN=0;			 //����Ϊ����ģʽ
	delay_ms(5);			 //ʹ����ʱ����ֹ������մ���	
}








//RS485B��ѯ���յ�������
//buf:���ջ����׵�ַ
//len:���������ݳ���
void RS485B_Receive_Data(u8 *buf,u8 *len)
{
	u8 rxlen=RS485B_RX_CNT;
	u8 i=0;
	*len=0;				//Ĭ��Ϊ0
	delay_ms(10);		//�ȴ�10ms,��������10msû�н��յ�һ������,����Ϊ���ս���
	if(rxlen==RS485B_RX_CNT&&rxlen)//���յ�������,�ҽ��������
	{
		for(i=0;i<rxlen;i++)
		{
			buf[i]=RS485B_RX_BUF[i];	
		}		
		*len=RS485B_RX_CNT;	//��¼�������ݳ���
		RS485B_RX_CNT=0;		//����
	}
}
