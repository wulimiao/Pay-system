#include "output.h"

//////////////////////////////////////////////////////////////////////////////////	 

//���������������	   
									  
////////////////////////////////////////////////////////////////////////////////// 	   

void OUTPUT_Init(void)
{
 
 GPIO_InitTypeDef  GPIO_InitStructure;
 	
 RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB|RCC_APB2Periph_GPIOE|RCC_APB2Periph_GPIOF, ENABLE);	 //ʹ��PE��PF�˿�ʱ��

 GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0|GPIO_Pin_1|GPIO_Pin_2|GPIO_Pin_3|GPIO_Pin_4;	 //IO-->PF1��PF2��PF3��PF4 �˿�����
 GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 		                     //�������
 GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		                     //IO���ٶ�Ϊ50MHz
 GPIO_Init(GPIOF, &GPIO_InitStructure);					                     //�����趨������ʼ��PF1��PF2��PF3��PF4
 GPIO_SetBits(GPIOF,GPIO_Pin_1|GPIO_Pin_2|GPIO_Pin_3|GPIO_Pin_4);			 //PF1��PF2��PF3��PF4 �����
 GPIO_SetBits(GPIOF,GPIO_Pin_0);
 GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0 |GPIO_Pin_2;	                     //LED�˿����� 
 GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;		                     //�������
 GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		                     // IO���ٶ�Ϊ50MHz
 GPIO_Init(GPIOE, &GPIO_InitStructure);	  				                     //�����趨������ʼ��PE0��PE2
 GPIO_SetBits(GPIOE,GPIO_Pin_0 |GPIO_Pin_2); 			                     //PE0 PE2 �����

 GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5 ;	                     //LED�˿����� 
 GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;		                     //�������
 GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		                     // IO���ٶ�Ϊ50MHz
 GPIO_Init(GPIOE, &GPIO_InitStructure);	  				                     //�����趨������ʼ��PE0��PE2
 GPIO_SetBits(GPIOE,GPIO_Pin_5); 			                     //PE0 PE2 �����

 GPIO_InitStructure.GPIO_Pin = GPIO_Pin_5 ;	                     //LED�˿����� 
 GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP;		                     //�������
 GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;		                     // IO���ٶ�Ϊ50MHz
 GPIO_Init(GPIOB, &GPIO_InitStructure);	  				                     //�����趨������ʼ��PE0��PE2
 GPIO_SetBits(GPIOB,GPIO_Pin_5); 			                     //PE0 PE2 �����
 
}
 
