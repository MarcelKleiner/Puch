/*
 * Flash.h
 *
 *  Created on: Apr 22, 2024
 *      Author: marce
 */

#ifndef SRC_FLASH_FLASH_H_
#define SRC_FLASH_FLASH_H_

#include "stm32g4xx_hal.h"

#define FLASH_PAGES 				((FLASH_SIZE) / FLASH_PAGE_SIZE)
constexpr auto UFLASH_DATA_SIZE = 64;

constexpr auto FLASH_STAR_PAGE_ADDR = 0x0800F800;
constexpr auto UFLASH_SIZE = 5;
constexpr auto UFLASH_PAGE = 127;
constexpr auto UFLASH_NPAGES = 1;



class Flash
{

public:

     Flash();

     HAL_StatusTypeDef Save();
     void ReadFlash();
     void WriteFlash();
     void SaveDefault();

		uint64_t GetDacOutput();
		void SetDacOutput(uint64_t dacOutput);

		uint64_t GetFetOffValue();
		void SetFetOffValue(uint64_t fetOffValue);

		uint64_t GetFetOnValue();
		void SetFetOnValue(uint64_t fetOnValue);

		uint64_t IsRelayInverted();
		void SetRelayInverted(uint64_t isRelayInverted);

private:

     uint64_t tmpFlashArray[UFLASH_SIZE];

     uint64_t _isRelayInverted = 0;
     uint64_t _dacOutput = 780;		//I set
     uint64_t _fetOnValue = 1570;	//current on
     uint64_t _fetOffValue = 1150;	//current off

};

#endif /* SRC_FLASH_FLASH_H_ */
