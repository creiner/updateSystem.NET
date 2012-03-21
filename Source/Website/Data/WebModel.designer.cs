﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="net.updatesystem")]
	public partial class WebModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDownload(Download instance);
    partial void UpdateDownload(Download instance);
    partial void DeleteDownload(Download instance);
    #endregion
		
		public WebModelDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["net_updatesystemConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public WebModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WebModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Download> Downloads
		{
			get
			{
				return this.GetTable<Download>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Downloads")]
	public partial class Download : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Alias;
		
		private string _Filename;
		
		private int _Hits;
		
		private byte _isPrivate;
		
		private string _friendlyName;
		
		private string _Description;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnAliasChanging(string value);
    partial void OnAliasChanged();
    partial void OnFilenameChanging(string value);
    partial void OnFilenameChanged();
    partial void OnHitsChanging(int value);
    partial void OnHitsChanged();
    partial void OnisPrivateChanging(byte value);
    partial void OnisPrivateChanged();
    partial void OnfriendlyNameChanging(string value);
    partial void OnfriendlyNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    #endregion
		
		public Download()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="PKdld_id", Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="dld_alias", Storage="_Alias", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Alias
		{
			get
			{
				return this._Alias;
			}
			set
			{
				if ((this._Alias != value))
				{
					this.OnAliasChanging(value);
					this.SendPropertyChanging();
					this._Alias = value;
					this.SendPropertyChanged("Alias");
					this.OnAliasChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="dld_filename", Storage="_Filename", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Filename
		{
			get
			{
				return this._Filename;
			}
			set
			{
				if ((this._Filename != value))
				{
					this.OnFilenameChanging(value);
					this.SendPropertyChanging();
					this._Filename = value;
					this.SendPropertyChanged("Filename");
					this.OnFilenameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="dld_hits", Storage="_Hits", DbType="Int NOT NULL")]
		public int Hits
		{
			get
			{
				return this._Hits;
			}
			set
			{
				if ((this._Hits != value))
				{
					this.OnHitsChanging(value);
					this.SendPropertyChanging();
					this._Hits = value;
					this.SendPropertyChanged("Hits");
					this.OnHitsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="dld_is_private", Storage="_isPrivate", DbType="TinyInt NOT NULL")]
		public byte isPrivate
		{
			get
			{
				return this._isPrivate;
			}
			set
			{
				if ((this._isPrivate != value))
				{
					this.OnisPrivateChanging(value);
					this.SendPropertyChanging();
					this._isPrivate = value;
					this.SendPropertyChanged("isPrivate");
					this.OnisPrivateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="dld_friendly_name", Storage="_friendlyName", DbType="VarChar(200)")]
		public string friendlyName
		{
			get
			{
				return this._friendlyName;
			}
			set
			{
				if ((this._friendlyName != value))
				{
					this.OnfriendlyNameChanging(value);
					this.SendPropertyChanging();
					this._friendlyName = value;
					this.SendPropertyChanged("friendlyName");
					this.OnfriendlyNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="dld_description", Storage="_Description", DbType="VARCHAR(8000)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
