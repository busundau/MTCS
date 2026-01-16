/*********************************************************************
*                 SEGGER Software GmbH                               *
*        Solutions for real time microcontroller applications        *
**********************************************************************
*                                                                    *
*        (c) 1996 - 2018  SEGGER Microcontroller GmbH                *
*                                                                    *
*        Internet: www.segger.com    Support:  support@segger.com    *
*                                                                    *
**********************************************************************

** emWin V5.48 - Graphical user interface for embedded applications **
All  Intellectual Property rights in the Software belongs to  SEGGER.
emWin is protected by  international copyright laws.  Knowledge of the
source code may not be used to write a similar product. This file may
only be used in accordance with the following terms:

The  software has  been licensed by SEGGER Software GmbH to Nuvoton Technology Corporationat the address: No. 4, Creation Rd. III, Hsinchu Science Park, Taiwan
for the purposes  of  creating  libraries  for its 
Arm Cortex-M and  Arm9 32-bit microcontrollers, commercialized and distributed by Nuvoton Technology Corporation
under  the terms and conditions  of  an  End  User  
License  Agreement  supplied  with  the libraries.
Full source code is available at: www.segger.com

We appreciate your understanding and fairness.
----------------------------------------------------------------------
Licensing information
Licensor:                 SEGGER Software GmbH
Licensed to:              Nuvoton Technology Corporation, No. 4, Creation Rd. III, Hsinchu Science Park, 30077 Hsinchu City, Taiwan
Licensed SEGGER software: emWin
License number:           GUI-00735
License model:            emWin License Agreement, signed February 27, 2018
Licensed platform:        Cortex-M and ARM9 32-bit series microcontroller designed and manufactured by or for Nuvoton Technology Corporation
----------------------------------------------------------------------
Support and Update Agreement (SUA)
SUA period:               2018-03-26 - 2019-03-27
Contact to extend SUA:    sales@segger.com
----------------------------------------------------------------------
File        : GUIConf.h
Purpose     : Configures emWins abilities, fonts etc.
----------------------------------------------------------------------
*/

#ifndef GUICONF_H
#define GUICONF_H

/*********************************************************************
*
*       Switching to ARGB ， Logical color format ARGB(default)
*/
// #define LCD_USE_COMPACT_COLOR_16

/*********************************************************************
*
*       Switching to ARGB ， Logical color format ARGB(default) 原始GUI.h定義為BGR，但使用採習慣RGB順序，故GUI_USE_ARGB要設定=1
*/
// #define GUI_USE_ARGB	0		//Logo紅色，框粉色，ABGR(1=亮)。UM03001_emWin5.pdf.P319。GTF128160-017703
#define GUI_USE_ARGB	1		//Logo藍色，框粉色，ARGB(default)。UM03001_emWin5.pdf.P319。GTF240320-0240C3，GTF240320-020002與GTF240240-0154A3

/*********************************************************************
*
*       Multi layer/display support
*/
#define GUI_NUM_LAYERS            1    // Maximum number of available layers

/*********************************************************************
*
*       Multi tasking support
*/
#define GUI_OS                    (0)  // Compile with multitasking support

/*********************************************************************
*
*       Configuration of touch support
*/
// #define GUI_SUPPORT_TOUCH         (1)  // Support a touch screen (req. win-manager)
#define GUI_SUPPORT_TOUCH         (0)  // Support a touch screen (req. win-manager) //2021/10/19

/*********************************************************************
*
*       Default font
*/
// #define GUI_DEFAULT_FONT          &GUI_Font6x8
#define GUI_DEFAULT_FONT          &GUI_FONT_32_1

/*********************************************************************
*
*         Configuration of available packages
*/
#define GUI_SUPPORT_MOUSE    1    // Mouse support。2021/11/04 設1才能使用Cursor API
#define GUI_WINSUPPORT       1    // Use Window Manager
#define GUI_SUPPORT_MEMDEV   1    // Use Memory Devices
#define GUI_SUPPORT_DEVICES  1    // Enable use of device pointers

#endif  // Avoid multiple inclusion

/*************************** End of file ****************************/
