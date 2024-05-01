/*
 * USBCom.h
 *
 *  Created on: Apr 17, 2020
 *      Author: marce
 */




#ifndef SRC_USB_USBCOM_H_
#define SRC_USB_USBCOM_H_

#include "stm32g4xx_hal.h"
#include "usb_device.h"
#include "usbd_cdc_if.h"
#include "../Flash/Flash.h"


#define USB_TIMEOUT		300



class USB_Com {
public:
	USB_Com(Flash *flash);

	bool Transmit(uint8_t *data, uint8_t size);
	void Receive(uint8_t *data, uint8_t size);

private:
	Flash *_flash;
};

#endif /* SRC_USB_USBCOM_H_ */
