using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UCchip.Reader.API
{
    public enum Commands : byte
    {
        cmd_reset = 0x70,
        cmd_set_uart_baudrate = 0x71,
        cmd_get_firmware_version = 0x72,
        cmd_set_reader_address = 0x73,
        cmd_set_work_antenna = 0x74,
        cmd_get_work_antenna = 0x75,
        cmd_set_output_power = 0x76,
        cmd_set_4_ant_power = 0x5f,
        cmd_set_8_ant_power = 0x5e,
        cmd_get_output_power = 0x77,
        cmd_set_frequency_region = 0x78,
        cmd_get_frequency_region = 0x79,
        cmd_set_beep_mode = 0x7a,
        cmd_get_reader_temperature = 0x7B,
        cmd_set_temporary_output_power = 0x66,
        cmd_set_rf_link_profile = 0x69,
        cmd_get_rf_link_profile = 0x6A,
        cmd_check_ant = 0xE0,
        cmd_inventory = 0x80,
        cmd_read = 0x81,
        cmd_write = 0x82,
        cmd_lock = 0x83,
        cmd_kill = 0x84,
        cmd_set_access_epc_match = 0x85,
        cmd_get_access_epc_match = 0x86,
        cmd_fast_switch_ant_inventory = 0x87,
        cmd_real_time_inventory = 0x89,
        cmd_custom_inventory = 0x8a,
        cmd_customized_session_target_invent = 0x8B,
        cmd_stop_inventory = 0x8C,
        cmd_get_inventory_buffer = 0x90,
        cmd_get_and_reset_inventory_buffer = 0x91,
        cmd_get_inventory_buffer_tag_count = 0x92,
        cmd_reset_inventory_buffer = 0x93,

        cmd_sm7_write = 0x95,
        cmd_sm7_read = 0x96,
        cmd_sm7_pk_update = 0x97,

        cmd_gb_seu_write = 0x42,
        cmd_gb_seu_read = 0x43,
        cmd_gb_read = 0x45,
        cmd_gb_write = 0x46,
        cmd_gb_lock = 0x47,
        cmd_gb_kill = 0x49,
        cmd_gb_mul_seu_auth = 0x98,

        cmd_reader_para_save = 0x4a,
        cmd_reader_para_reset = 0x4b,
        cmd_reader_app_upgrade = 0x4c,
        cmd_baseband_firmware_upgrade = 0x4d,

        cmd_get_gpio_status = 0x60,
        cmd_set_gpio_status = 0x61,
        cmd_get_mulTag_mode_status = 0x50,
        cmd_set_mulTag_mode_status = 0x51,

        cmd_castom_inv_match_magnus = 0x52,
        cmd_castom_inv_match_tid = 0x53,
        cmd_castom_inv_match_epc = 0x54,
        cmd_castom_inv_uasrdata = 0x55,
        cmd_castom_inv_userdefine = 0x59,

        cmd_bidirectional_authentication = 0x98,
        cmd_set_tx_time = 0x5d,
        cmd_get_tx_time = 0x5c,
        cmd_set_session_target = 0x5b,
        cmd_get_session_target = 0x5a,
        cmd_set_cw = 0x3e,
        cmd_get_cw = 0x3f,
        cmd_set_keepalive = 0x4e,
        cmd_get_keepalive = 0x4f,
        cmd_set_select = 0x8d,
        cmd_get_select = 0x8e,
        cmd_temperature_warning = 0xe1,
    }
}
