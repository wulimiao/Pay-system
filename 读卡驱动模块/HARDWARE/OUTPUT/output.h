#ifndef __OUTPUT_H
#define __OUTPUT_H	 
#include "sys.h"
//////////////////////////////////////////////////////////////////////////////////	 

//���������������	   
									  
////////////////////////////////////////////////////////////////////////////////// 
#define LEDA PBout(5)          // PE0
#define LEDB PEout(5)          // PE2	
/*
#define BZJS PFin(5)           // PF5�����ϼ����ź�
#define BZTC PFin(6)           // PF6������ͣ���ź�	
#define XJMXF PFin(7)          // PF7ǰѭ�������ź�
#define XJMXB PFin(8)          // PF��ѭ�������ź�
*/
#define BEEP    PFout(0)       // PF0������
#define qmotor1 PFout(1)       // PF1ǰ����������ź�
#define qmotor2 PFout(2)       // PF2ǰ��������ź�	
#define qmotor3 PFout(3)       // PF3������������ź�
#define qmotor4 PFout(4)       // PF4������������ź�

void OUTPUT_Init(void);           //��ʼ��

		 				    
#endif
