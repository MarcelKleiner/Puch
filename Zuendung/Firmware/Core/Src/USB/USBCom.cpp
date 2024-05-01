/*
 * USBCom.cpp
 *
 *  Created on: Apr 17, 2020
 *      Author: marce
 */

#include "USBCom.h"

USB_Com::USB_Com(Flash *flash)
{
	_flash = flash;
}


bool USB_Com::Transmit(uint8_t *data, uint8_t size){
	while(CDC_Transmit_FS((uint8_t*) data, size) != USBD_OK){}
	return true;	//Transmit successful
}


void USB_Com::Receive(uint8_t *data, uint8_t size)
{
    uint8_t txData[10];

    txData[0] = '@';
    txData[1] = '#';
    txData[2] = '1';

    if(data[0] != '#' || data[1] != '!')
    {
		txData[2] = '0';
	    Transmit(txData, 3);
    	return;
    }

    switch(data[2]){
    	case '0':
    		txData[0] = _flash->IsRelayInverted();

    		txData[1] = (_flash->GetDacOutput()>> 8);
    		txData[2] = _flash->GetDacOutput();

    		txData[3] = (_flash->GetFetOffValue()>> 8);
    		txData[4] = _flash->GetFetOffValue() ;

    		txData[5] = (_flash->GetFetOnValue()>> 8);
    		txData[6] = _flash->GetFetOnValue();
    	    Transmit(txData, 7);
    	    return;
    	case '1':
    		_flash->SetRelayInverted(((data[3]<<8) + data[4]));
    		break;
    	case '2':
    		_flash->SetDacOutput(((data[3]<<8) + data[4]));
    		break;
    	case '3':
    		_flash->SetFetOffValue(((data[3]<<8) + data[4]));
    		break;
    	case '4':
    		_flash->SetFetOnValue(((data[3]<<8) + data[4]));
    		break;
    	case '5':
    		_flash->Save();
    		break;
    	default:
    		txData[2] = '0';
    }

    Transmit(txData, 3);
}
