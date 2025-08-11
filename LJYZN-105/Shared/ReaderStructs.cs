using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJYZN_105
{
    //internal class ReaderStructs
    //{
    //}

    enum TagErrCode
    {
        ERR_OTHER,
        ERR_MEM_OVERRUN = 3,
        ERR_MEM_LOCKED,
        ERR_INSUFFICIENT_POWER = 0xB,
        ERR_NON_SPECIFIC = 0x0F
    }

    enum MemBank : Byte
    {
        Reserved = 0,
        EPC,
        TID,
        User
    }

    enum COMMANDS
    {
        //EPC C1 G2 (ISO18000-6C)
        CMD_INVENTORY = 0x01,
        CMD_READ_DATA,
        CMD_WRITE_DATA,
        CMD_WRITE_EPC,
        CMD_KILL_TAG,
        CMD_LOCK,
        CMD_BLOCK_ERASE,
        CMD_READ_PROTECT,
        CMD_READ_PROTECT_NOEPC,
        CMD_RESET_READ_PROTECT,
        CMD_CHECK_READ_PROTECT,
        CMD_EAS_ALARM,
        CMD_CHECK_EAS_ALARM,
        CMD_BLOCK_LOCK,
        CMD_INVENTORY_SINGLE,
        CMD_BLOCK_WRITE,

        //Reader defined commands
        CMD_GET_READER_INFO = 0x21,
        CMD_SET_REGION,
        CMD_SET_ADDRESS = 0x24,
        CMD_SET_SCANTIME,
        CMD_BAUD_RATE = 0x28,
        CMD_SET_POWER = 0x2F,
        CMD_ACOUSTO_OPTIC_CTL = 0x33,
        CMD_BUZZER_CTL = 0x35,

        //ISO18000-6B
        CMD_6B_INV_SIGNAL = 0x50,
        CMD_6B_INV_MULTI,
        CMD_6B_READ_DATA,
        CMD_6B_WRITE_DATA,
        CMD_6B_CHECK_LOCK,
        CMD_6B_LOCK,
    }

}
