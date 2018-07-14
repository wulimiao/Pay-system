#include "output.h"
#include "delay.h"
#include "sys.h"
#include "rc522.h"
#include "lcd.h"			 //显示模块
#include "key.h"             //矩阵键盘模块
#include "usart.h"
#include "string.h" 
#include "stdio.h"
#include "beep.h"
//////////////////////////////////////////////////////////
//M1卡分為16個扇區，每個扇區由4塊（塊0、塊1、塊2、塊3）組成
//我們也將16個扇區的64個塊按絕對地址編號0~63
//第0扇區的塊0（即絕對地址0塊），他用於存放廠商代碼，已經固化，不可更改
//每個扇區的塊0、塊1、塊2為數據塊，可用於存放數據
//每個扇區的塊3為控制塊（絕對地址塊3、7、11....），包括了密碼A，存取控制、密碼B。

/*******************************
*连线说明：
*1--SS  <----->PF0
*2--SCK <----->PB13
*3--MOSI<----->PB15
*4--MISO<----->PB14
*5--悬空
*6--GND <----->GND
*7--RST <----->PF1
*8--VCC <----->VCC
************************************/
/*全局变量*/
unsigned char CT[2];//卡类型
unsigned char SN[4]; //卡号
unsigned char RFID[16];			//存放RFID 
unsigned char lxl_bit=0;
unsigned char card1_bit=0;
unsigned char card2_bit=0;
unsigned char card3_bit=0;
unsigned char card4_bit=0;
unsigned char total=0;
unsigned char lxl[4]={6,109,250,186};
unsigned char card_1[4]={66,193,88,0};
unsigned char card_2[4]={66,191,104,0};
unsigned char card_3[4]={62,84,28,11};
unsigned char card_4[4]={126,252,248,12};
u8 KEY[6]={0xff,0xff,0xff,0xff,0xff,0xff};
unsigned char RFID1[16]={0x00,0x00,0x00,0x00,0x00,0x00,0xff,0x07,0x80,0x29,0xff,0xff,0xff,0xff,0xff,0xff};
/*函数声明*/
void ShowID(u16 x,u16 y, u8 *p, u16 charColor, u16 bkColor);	 //显示卡的卡号，以十六进制显示
void PutNum(u16 x,u16 y, u32 n1,u8 n0, u16 charColor, u16 bkColor);	//显示余额函数
void Store(u8 *p,u8 store,u8 cash);//最重要的一个函数	
int main(void)
{		
	unsigned char status;
	unsigned char s=0x08;
	//u8 Data[16];
	//u8 i;
	u8 t,key;
	//u8 k;//读写错误重试次数
	u8 j; 

 	delay_init();	    	 //延时函数初始化	  
	NVIC_Configuration(); 	 //设置NVIC中断分组2:2位抢占优先级，2位响应优先级
 	OUTPUT_Init();			 //输出模块初始化
	uart_init(9600);				
	LCD_Init();
	KEY_Init();
	InitRc522();				//初始化射频卡模块
	//sprintf((char*)lcd_id,"LCD ID:%04X",lcddev.id);//将LCD ID打印到lcd_id数组。
	LEDA=1; 
	MYBEEP_init();
  	while(1) 
	{		key=KEY_Scan(0);
	       	if(key==1){s++;LCD_ShowNum(0,272,s,3,16);}
			else if(key==3) {s--;LCD_ShowNum(0,272,s,3,16);}
			status = PcdRequest(PICC_REQALL,CT);/*尋卡*/
			if(status==MI_OK)//尋卡成功
			{
			 LCD_ShowString(0,30,200,16,16,"PcdRequest_MI_OK");
			 status=MI_ERR;
			 status = PcdAnticoll(SN);/*防冲撞*/
			 
			}




			if (status==MI_OK)//防衝撞成功
			{
				LCD_ShowString(150,30,200,16,16,"PcdAnticoll_MI_OK");
				status=MI_ERR;		
				LEDA=1;
				LEDB=1;
				ShowID(0,200,SN,BLUE,WHITE); //在液晶屏上显示卡的ID号
				printf("ID:%02x %02x %02x %02x\n",SN[0],SN[1],SN[2],SN[3]);//发送卡号
				LCD_ShowString(0,100,200,16,16,"The Card ID is:");
//				printf("The Card ID is:%d%d%d%d",SN[0],SN[1],SN[2],SN[3]);
				for(j=0;j<4;j++)
				{
					 LCD_ShowNum(0,116+j*16,SN[j],3,16);
				}
				if((SN[0]==lxl[0])&&(SN[1]==lxl[1])&&(SN[2]==lxl[2])&&(SN[3]==lxl[3]))
				{
					lxl_bit=1;
					LCD_ShowString(0,0,200,16,16,"The User is:lxl");
				}
				if((SN[0]==card_1[0])&&(SN[1]==card_1[1])&&(SN[2]==card_1[2])&&(SN[3]==card_1[3]))
				{
					card1_bit=1;
					LCD_ShowString(0,0,200,16,16,"The User is:card_1");
				}
				if((SN[0]==card_2[0])&&(SN[1]==card_2[1])&&(SN[2]==card_2[2])&&(SN[3]==card_2[3]))
				{
					card2_bit=1;
					LCD_ShowString(0,0,200,16,16,"The User is:card_2");
				}
				
				if((SN[0]==card_3[0])&&(SN[1]==card_3[1])&&(SN[2]==card_3[2])&&(SN[3]==card_3[3]))
				{
					card3_bit=1;
					LCD_ShowString(0,0,200,16,16,"The User is:card_3");
				}
				if((SN[0]==card_4[0])&&(SN[1]==card_4[1])&&(SN[2]==card_4[2])&&(SN[3]==card_4[3]))
				{
					card4_bit=1;
					LCD_ShowString(0,0,200,16,16,"The User is:card_4");
				}
				total=card1_bit+card2_bit+card3_bit+card4_bit+lxl_bit;
				LCD_ShowString(0,16,200,16,16,"total:");
				LCD_ShowNum(46,16,total,2,16);

				status =PcdSelect(SN);
				//Reset_RC522();
		
			}
			else
			{
				LEDA=0;//只点亮led0
				LEDB=1;
			}
			if(status==MI_OK)//選卡成功
			{
			 //LCD_ShowString(0,50,200,16,16,"PcdAnticoll_MI_OK");
			 LCD_ShowString(0,48,200,16,16,"PcdSelect_MI_OK  ");
			 status=MI_ERR;
			 status =PcdAuthState(0x60,0x09,KEY,SN);
			 }
			 if(status==MI_OK)//驗證成功
			 {
			  LCD_ShowString(0,64,200,16,16,"PcdAuthState_MI_OK  ");
			  status=MI_ERR;
			  status=PcdRead(s,RFID);
			  //status=PcdWrite(s,RFID1);
			  }

			if(status==MI_OK)//讀卡成功
			 {
			  LCD_ShowString(0,80,200,16,16,"READ_MI_OK");
				 if(SN[0]==0x43&&SN[1]==0xf8&&SN[2]==0xeb&&SN[3]==0x3f)
				 {
					 BEEP1=1;
					 delay_ms(10000);
					 BEEP1=0;
				 }
			  status=MI_ERR;
			  delay_ms(10000);
			 }
			if(key==2)
			{
			for(t=0;t<16;t++)                                        //开启射频模块
	        {
	         USART_ClearFlag(USART1,USART_FLAG_TC);                 //读取USART_SR
	         USART_SendData(USART1,RFID[t]);                         //向串口2发送数据
	         while(USART_GetFlagStatus(USART1,USART_FLAG_TC)!=SET); //等待发送结束
         	}
			}
			//else LCD_ShowString(0,80,200,16,16,"READ_MI_ERR ");
//////////////////////////////////////////////////////////////////////////////////////////////////////
			  /*if(status==MI_OK)
			  {
			   LCD_ShowString(120,80,200,16,16,"WRITE_MI_OK");
			   status=MI_ERR;
			  }*/
			  //else LCD_ShowString(120,80,200,16,16,"WRITE_MI_ERR");
			  //Reset_RC522();
	}
			
			
//////////////////////////////		
           }
			



/*************************************
*函数功能：显示卡的卡号，以十六进制显示
*参数：x，y 坐标
*		p 卡号的地址
*		charcolor 字符的颜色
*		bkcolor   背景的颜色
***************************************/
void ShowID(u16 x,u16 y, u8 *p, u16 charColor, u16 bkColor)	 //显示卡的卡号，以十六进制显示
{
	u8 num[9];
	u8 i;

	for(i=0;i<4;i++)
	{
		num[i*2]=p[i]/16;
		num[i*2]>9?(num[i*2]+='7'):(num[i*2]+='0');
		num[i*2+1]=p[i]%16;
		num[i*2+1]>9?(num[i*2+1]+='7'):(num[i*2+1]+='0');
	}
	num[8]=0;
	POINT_COLOR=RED;	  
	LCD_ShowString(x,y,200,16,16,"The Card ID is:");	
	//DisplayString(x,y+16,num,charColor,bkColor);
 	for(i=0;i<8;i++)
	{
		  LCD_ShowNum(x+16*i,y+16,num[i],2,16);
		  //LCD_ShowNum(x,y+32,num[1],2,16);
		 // LCD_ShowNum(x,y+48,num[2],2,16);
		 // LCD_ShowNum(x,y+64,num[3],2,16);
		  
		 // LCD_ShowNum(x,y+80,num[4],2,16);
		 // LCD_ShowNum(x,y+96,num[5],2,16);
		 // LCD_ShowNum(x,y+16*7,num[6],2,16);
		 // LCD_ShowNum(x,y+16*8,num[7],2,16);
		 // LCD_ShowNum(x,y+16*9,num[8],2,16);
		 // LCD_ShowNum(x,y+16*10,num[9],2,16);
	}
	
}
/********************************
*函数功能：求p的n次幂
*/
int power(u8 p,u8 n)
{
	int pow=1;
	u8 i;
	for(i=0;i<n;i++)
	{
		pow*=p;	
	}
	return pow;
}
 
u8 ReadData(u8   addr,u8 *pKey,u8 *pSnr,u8 *dataout)
{
	u8 status,k;
	status=0x02;//
	k=5;
	do
    {
		status=PcdAuthState(PICC_AUTHENT1A,addr,pKey,pSnr);
		k--;
		//printf("AuthState is wrong\n");						      
    }while(status!=MI_OK && k>0);

	status=0x02;//
	k=5;
	do
    {
		status=PcdRead(addr,dataout);
		k--;
		//printf("ReadData is wrong\n");							      
    }while(status!=MI_OK && k>0);
	return status;
}
u8 WriteData(u8   addr,u8 *pKey,u8 *pSnr,u8 *datain)
{
	u8 status,k;
	status=0x02;//
	k=5;
	do
    {
		status=PcdAuthState(PICC_AUTHENT1A,addr,pKey,pSnr);
		k--;
		//printf("AuthState is wrong\n");						      
    }while(status!=MI_OK && k>0);

	status=0x02;//
	k=5;
	do
    {
		status=PcdWrite(addr,datain);
		k--;
		//printf("ReadData is wrong\n");							      
    }while(status!=MI_OK && k>0);
	return status;
}
void PutNum(u16 x,u16 y, u32 n1,u8 n0, u16 charColor, u16 bkColor)
{
//	u8 tmp[13];
//	u8 i;

	//LCD_SetRegion(0,0,239,319,FALSE);
//	tmp[0]=n1/1000000000+'0';
//	for(i=1;i<10;i++)
//	{
///		tmp[i]=n1/(1000000000/power(10,i))%10+'0';
//	}
//	tmp[10]='.';
//	tmp[11]=n0+'0';
//	tmp[12]=0;
	//DisplayString(x,y,tmp,charColor,bkColor);
	//LCD_ShowString(x,y,)

	
}
void Store(u8 *p,u8 store,u8 cash)
{

}

