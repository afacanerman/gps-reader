namespace SerialPortListen
{
    public enum QualityCode
    {
        Invalid = 0,
        GPS_fix_SPS = 1,
        DGPS_fix = 2,
        PPS_fix = 3,
        Real_Time_Kinematic = 4,
        Float_RTK = 5,
        Estimated = 6,
        Manual_Input_Mode = 7,
        Simulation_Mode = 8
    }
}