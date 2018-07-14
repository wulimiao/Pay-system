#ifndef __RS485_H
#define __RS485_H			 
#include "sys.h"	 								  
//////////////////////////////////////////////////////////////////////////////////	 

//RS485���� ����	   
									  
//////////////////////////////////////////////////////////////////////////////////

#define RS485_REC_LEN  			64  	//�����������ֽ��� 64
	  		  	
extern u8 RS485A_RX_BUF[RS485_REC_LEN]; 	//���ջ���,���RS485_REC_LEN���ֽ�.
extern u8 RS485A_RX_CNT;   			    //���յ������ݳ���

extern u8 RS485B_RX_BUF[RS485_REC_LEN]; 	//���ջ���,���RS485_REC_LEN���ֽ�.
extern u8 RS485B_RX_CNT;   			    //���յ������ݳ���

//ģʽ����
#define RS485A_TX_EN		PBout(8)	//485ģʽ����.0,����;1,����.
#define RS485B_TX_EN		PCout(12)	//485ģʽ����.0,����;1,����.
//����봮���жϽ��գ��벻Ҫע�����º궨��
#define EN_USART3_RX 	1			//0,������;1,����.
#define EN_UART4_RX 	1			//0,������;1,����.



void RS485A_Init(u32 bound);
void RS485B_Init(u32 bound);
void RS485A_Send_Data(u8 *buf,u8 len);
void RS485A_Receive_Data(u8 *buf,u8 *len);
void RS485A_Perfect_Send_Data(u8 *buf,u8 len);
void RS485B_Send_Data(u8 *buf,u8 len);
void RS485B_Receive_Data(u8 *buf,u8 *len);
void RS485B_Perfect_Send_Data(u8 *buf,u8 len);

#endif	   
















