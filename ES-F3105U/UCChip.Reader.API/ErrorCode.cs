using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCchip.Reader.API
{
    public enum ErrorCode : byte
    {
        OK = 0,
        Timeout = 1,
        NoResponse = 2,
        ParameterError = 4,
        SystemError = 8,

        RREC_BUSY = 3,

        RREC_SUCCESS = 0x10,
        RREC_FAIL = 0x11,
        CUSTOM_INV_COMPLET = 0x12,
        FAST_SWANT_INV_COMPLET = 0x13,
        RREC_MCU_REST_ERR = 0x20,
        CW_ON_ERR = 0x21,
        ANT_MISS_ERR = 0x22,
        WRITE_FLASH_ERR = 0x23,
        READ_FLASH_ERR = 0x24,
        SET_OUTPUT_POWER_ERR = 0x25,
        TAG_INVENTORY_ERR = 0x31,
        TAG_READ_ERR = 0x32,
        TAG_WRITE_ERR = 0x33,
        TAG_LOCK_ERR = 0x34,
        TAG_KILL_ERR = 0x35,
        NO_TAG_ERROR = 0x36,
        INV_OK_BUT_ACC_FAIL = 0x37,
        BUF_IS_EMPTY_ERR = 0x38,
        ACC_OR_PASSOWRD_ERR = 0x40,
        RREC_UNSUPPORTED = 0x41,
        PARAM_WORDCNT_TOO_LONG = 0x43,
        PARAM_MEMBANK_OUTOF_RANGE = 0x44,
        PARAM_LOCK_REGION_OUTOF_RANGE = 0x45,
        PARAM_READER_ADDRESS_INVALID = 0x46,
        PARAM_ANT_ID_OUTOF_RANGE = 0x47,
        PARAM_OUTPUT_POWER_OUTOF_RANGE = 0x48,
        PARAM_FREQ_REGION_OUT_OF_RANGE = 0x49,
        PARAM_BAUDRATE_OUTOF_RANGE = 0x4A,
        PARAM_BEEPER_MODE_OUTOF_RANGE = 0x4B,
        PARAM_EPC_MATCH_LEN_TOO_LONG = 0x4C,
        PARAM_EPC_MATCH_LEN_ERR = 0x4D,
        PARAM_EPC_MATCH_MODE_INVALID = 0x4E,
        PARAM_FREQ_RANGE_INVALID = 0x4F,
        FAIL_TO_GET_RN16_FROM_TAG = 0x50,
        PARAM_DRM_MODE_INVALID = 0x51,
        PLL_LOCK_FAIL = 0x52,
        RF_CHIP_FAIL_TO_RESPONSE = 0x53,
        FAIL_TO_ACHIEVE_DESIRED_OUTPUT_POWER = 0x54,
        SPECTRUM_REGULATION_ERR = 0x56,
        OUTPUT_POWER_TOO_LOW = 0x57,
        SM7_DOUBLE_IDENTIFY_FAILD = 0x58,
        SM7_DOUBLE_IDENTIFY_SUCCESS = 0x59,
        ERROR_GB_NO_POWER = 0x60,
        ERROR_GB_NO_PERMISSION = 0x61,
        ERROR_GB_MEM_OVER_LIMIT = 0x62,
        ERROR_GB_MEM_LOCK = 0x63,
        ERROR_GB_PASSWORD_ERR = 0x64,
        ERROR_GB_IDENTIFY_ERR = 0x65,
        ERROR_GB_UNKNOW_ERR = 0x66,
        CONNECT_ADDR_ERR = 0x67,
    }
}
