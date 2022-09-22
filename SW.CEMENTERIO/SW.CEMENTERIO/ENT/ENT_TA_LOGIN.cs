using System;

namespace SW.CEMENTERIO.EntityLayer
{
	public class ENT_TA_LOGIN : ENT_TA_COLABORADOR
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ENT_TA_LOGIN class.
		/// </summary>
		public ENT_TA_LOGIN()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_LOGIN class.
		/// </summary>
		public ENT_TA_LOGIN(int LOGN_IDCOLABORADOR, string LOGS_USUARIO, string LOGS_CLAVE, string LOGS_USUREGISTRO, DateTime LOGD_FECREGISTRO, string LOGS_USUMODIFICA, DateTime LOGD_FECMODIFICA, bool LOGB_ESTADO)
		{
			this.LOGN_IDCOLABORADOR = LOGN_IDCOLABORADOR;
			this.LOGS_USUARIO = LOGS_USUARIO;
			this.LOGS_CLAVE = LOGS_CLAVE;
			this.LOGS_USUREGISTRO = LOGS_USUREGISTRO;
			this.LOGD_FECREGISTRO = LOGD_FECREGISTRO;
			this.LOGS_USUMODIFICA = LOGS_USUMODIFICA;
			this.LOGD_FECMODIFICA = LOGD_FECMODIFICA;
			this.LOGB_ESTADO = LOGB_ESTADO;
		}

		/// <summary>
		/// Initializes a new instance of the ENT_TA_LOGIN class.
		/// </summary>
		public ENT_TA_LOGIN(int LOGN_IDLOGIN, int LOGN_IDCOLABORADOR, string LOGS_USUARIO, string LOGS_CLAVE, string LOGS_USUREGISTRO, DateTime LOGD_FECREGISTRO, string LOGS_USUMODIFICA, DateTime LOGD_FECMODIFICA, bool LOGB_ESTADO)
		{
			this.LOGN_IDLOGIN = LOGN_IDLOGIN;
			this.LOGN_IDCOLABORADOR = LOGN_IDCOLABORADOR;
			this.LOGS_USUARIO = LOGS_USUARIO;
			this.LOGS_CLAVE = LOGS_CLAVE;
			this.LOGS_USUREGISTRO = LOGS_USUREGISTRO;
			this.LOGD_FECREGISTRO = LOGD_FECREGISTRO;
			this.LOGS_USUMODIFICA = LOGS_USUMODIFICA;
			this.LOGD_FECMODIFICA = LOGD_FECMODIFICA;
			this.LOGB_ESTADO = LOGB_ESTADO;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the LOGN_IDLOGIN value. 
		/// </summary>
		public int LOGN_IDLOGIN { get; set; }

		/// <summary>
		/// Gets or sets the LOGN_IDCOLABORADOR value. 
		/// </summary>
		public int LOGN_IDCOLABORADOR { get; set; }

		/// <summary>
		/// Gets or sets the LOGS_USUARIO value. 
		/// </summary>
		public string LOGS_USUARIO { get; set; }

		/// <summary>
		/// Gets or sets the LOGS_CLAVE value. 
		/// </summary>
		public string LOGS_CLAVE { get; set; }

		/// <summary>
		/// Gets or sets the LOGS_USUREGISTRO value. 
		/// </summary>
		public string LOGS_USUREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the LOGD_FECREGISTRO value. 
		/// </summary>
		public DateTime LOGD_FECREGISTRO { get; set; }

		/// <summary>
		/// Gets or sets the LOGS_USUMODIFICA value. 
		/// </summary>
		public string LOGS_USUMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the LOGD_FECMODIFICA value. 
		/// </summary>
		public DateTime LOGD_FECMODIFICA { get; set; }

		/// <summary>
		/// Gets or sets the LOGB_ESTADO value. 
		/// </summary>
		public bool LOGB_ESTADO { get; set; }

		#endregion
	}
}
