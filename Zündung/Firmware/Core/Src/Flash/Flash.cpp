/*
 * Flash.cpp
 *
 *  Created on: Apr 22, 2024
 *      Author: marce
 */

#include "Flash.h"

     Flash::Flash(){

     }

void Flash::ReadFlash()
{

	for (int i = 0; i < UFLASH_SIZE; i++)
	{
		tmpFlashArray[i] = *(uint64_t*) (FLASH_STAR_PAGE_ADDR + 64 * i);
	}

	if(tmpFlashArray[0] > 1){
		//flash is not initialised
		SaveDefault();
		return;
	}

	SetRelayInverted(tmpFlashArray[0]);
	SetDacOutput(tmpFlashArray[1]);
	SetFetOnValue(tmpFlashArray[2]);
	SetFetOffValue(tmpFlashArray[3]);
	return;
}

void Flash::SaveDefault()
{
	tmpFlashArray[0] = 0;
	tmpFlashArray[1] = 780;
	tmpFlashArray[2] = 1570;
	tmpFlashArray[3] = 1150;
	Save();
}

HAL_StatusTypeDef Flash::Save()
{

	FLASH_EraseInitTypeDef EraseinitStruct{};
	uint32_t sectorError = 0;

	if (HAL_FLASH_Unlock() != HAL_OK)
	{
		HAL_FLASH_Lock();
		return HAL_ERROR;
	}

	EraseinitStruct.TypeErase = FLASH_TYPEERASE_PAGES;
	EraseinitStruct.Banks = 1;
	EraseinitStruct.Page = UFLASH_PAGE;
	EraseinitStruct.NbPages = UFLASH_NPAGES;

	if (HAL_FLASHEx_Erase(&EraseinitStruct, &sectorError) != HAL_OK)
	{
		HAL_FLASH_Lock();
		return HAL_ERROR;
	}

	for (int i = 0; i < UFLASH_SIZE; i++)
	{
		HAL_FLASH_Program(FLASH_TYPEPROGRAM_DOUBLEWORD, (FLASH_STAR_PAGE_ADDR + 64 * i), tmpFlashArray[i]);
	}

	if (HAL_FLASH_Lock() != HAL_OK)
	{
		HAL_FLASH_Lock();
		return HAL_ERROR;
	}

	return HAL_OK;
}





uint64_t Flash::GetDacOutput()
{
	return _dacOutput;
}

void Flash::SetDacOutput(uint64_t dacOutput)
{
	_dacOutput = dacOutput;
}

uint64_t Flash::GetFetOffValue()
{
	return _fetOffValue;
}

void Flash::SetFetOffValue(uint64_t fetOffValue)
{
	_fetOffValue = fetOffValue;
}

uint64_t Flash::GetFetOnValue()
{
	return _fetOnValue;
}

void Flash::SetFetOnValue(uint64_t fetOnValue)
{
	_fetOnValue = fetOnValue;
}

uint64_t Flash::IsRelayInverted()
{
	return _isRelayInverted;
}

void Flash::SetRelayInverted(uint64_t isRelayInverted)
{
	_isRelayInverted = isRelayInverted;
}
