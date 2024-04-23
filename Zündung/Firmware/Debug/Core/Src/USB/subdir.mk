################################################################################
# Automatically-generated file. Do not edit!
# Toolchain: GNU Tools for STM32 (12.3.rel1)
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
CPP_SRCS += \
../Core/Src/USB/USBCom.cpp 

OBJS += \
./Core/Src/USB/USBCom.o 

CPP_DEPS += \
./Core/Src/USB/USBCom.d 


# Each subdirectory must supply rules for building sources it contributes
Core/Src/USB/%.o Core/Src/USB/%.su Core/Src/USB/%.cyclo: ../Core/Src/USB/%.cpp Core/Src/USB/subdir.mk
	arm-none-eabi-g++ "$<" -mcpu=cortex-m4 -std=gnu++14 -g3 -DDEBUG -DUSE_HAL_DRIVER -DSTM32G431xx -c -I../Core/Inc -I../Drivers/STM32G4xx_HAL_Driver/Inc -I../Drivers/STM32G4xx_HAL_Driver/Inc/Legacy -I../Drivers/CMSIS/Device/ST/STM32G4xx/Include -I../Drivers/CMSIS/Include -I../USB_Device/App -I../USB_Device/Target -I../Middlewares/ST/STM32_USB_Device_Library/Core/Inc -I../Middlewares/ST/STM32_USB_Device_Library/Class/CDC/Inc -O0 -ffunction-sections -fdata-sections -fno-exceptions -fno-rtti -fno-use-cxa-atexit -Wall -fstack-usage -fcyclomatic-complexity -MMD -MP -MF"$(@:%.o=%.d)" -MT"$@" --specs=nano.specs -mfpu=fpv4-sp-d16 -mfloat-abi=hard -mthumb -o "$@"

clean: clean-Core-2f-Src-2f-USB

clean-Core-2f-Src-2f-USB:
	-$(RM) ./Core/Src/USB/USBCom.cyclo ./Core/Src/USB/USBCom.d ./Core/Src/USB/USBCom.o ./Core/Src/USB/USBCom.su

.PHONY: clean-Core-2f-Src-2f-USB

