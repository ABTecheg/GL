/*
Copyright (C) 2004 Jacquelin POTIER <jacquelin.potier@free.fr>
Dynamic aspect ratio code Copyright (C) 2004 Jacquelin POTIER <jacquelin.potier@free.fr>

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; version 2 of the License.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/
using System; using Accounting_GeneralLedger.Report;

namespace Accounting_GeneralLedger
{
	/// <summary>
	/// Summary description for ClassOptions.
	/// </summary>
	public class ClassOptions
	{
        private const int COLUMNS_PANEL_NUMBER=5;
        public enum WINDOW_ORIENTATION{HORIZONTAL=0,VERTICAL};

        // local enums because error with xml serialization using ClassX.UNITS
        public enum TEMP_UNITS {FAHRENHEIT=0,CELCIUS};
        public enum WIND_UNITS {MS=0,KMH,MH,KNOTS,BEAUFORT};
        public enum HEIGTH_UNITS{INCH=0,MM};
        public enum LENGTH_UNITS{FEET=0,KM,METER,MILES};
        public enum PRESSURE_UNITS{INHG=0,MMHG,HPA,ATM};


        public ClassOptions.WIND_UNITS wind_unit=ClassOptions.WIND_UNITS.MH;
        public ClassOptions.TEMP_UNITS temp_unit=ClassOptions.TEMP_UNITS.FAHRENHEIT;
        public ClassOptions.PRESSURE_UNITS pressure_unit=ClassOptions.PRESSURE_UNITS.INHG;
        public ClassOptions.LENGTH_UNITS length_unit=ClassOptions.LENGTH_UNITS.METER;
        public ClassOptions.LENGTH_UNITS height_unit=ClassOptions.LENGTH_UNITS.FEET;
        public ClassOptions.HEIGTH_UNITS precipitation_height_unit=ClassOptions.HEIGTH_UNITS.INCH;

        public bool show_clouds_in_window=true;
        public bool show_temp_in_window=true;
        /*
        public bool show_wind_speed_in_window=true;
        public bool show_wind_dir_in_window=true;
        */
        public bool show_wind_in_window=true;
        public bool show_pressure_in_window=true;
        
        public bool show_clouds_in_satusbar=true;
        public bool show_temp_in_satusbar=true;
        public bool show_wind_speed_in_satusbar=true;
        public bool show_wind_dir_in_satusbar=true;

        //public ClassCity city=null;
        public bool top_most=true;
        public double opacity=0.70;
        public int window_pos_x=0;
        public int window_pos_y=0;
        public string report_language="";

        public UInt32 update_interval=3600;
        public UInt32 retry_interval=300;
        public string host="weather.noaa.gov";
        public ushort host_port=80;
        public string remote_dir="/pub/data/observations/metar/stations/";

        public bool proxy_used=false;
        //public easy_socket.proxy.ClassProxy.PROXY_TYPE proxy_type=easy_socket.proxy.ClassProxy.PROXY_TYPE.HTTP_GET;
        public string proxy_ip="127.0.0.1";
        public ushort proxy_port=80;
        public static  string Idpro;
        public int ColumnsPanelNumber
        {
            get
            {
                if (this.window_orientation==WINDOW_ORIENTATION.HORIZONTAL)
                    return COLUMNS_PANEL_NUMBER;
                else
                    return 1;
            }
        }
        public WINDOW_ORIENTATION window_orientation=WINDOW_ORIENTATION.HORIZONTAL;

        public ClassOptions()
        {
            //this.city=new ClassCity();
        }
        public static ClassOptions load(string config_file_name)
        {
            try
            {
                return (ClassOptions)XML_access.XMLDeserializeObject(config_file_name,typeof(ClassOptions));
            }
            catch
            {
                return new ClassOptions();
            }
        }
        public bool save(string config_file_name)
        {
            try
            {
                XML_access.XMLSerializeObject(config_file_name,this,typeof(ClassOptions));
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message,"Error",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                return false;            
            }
        }
	}
}
