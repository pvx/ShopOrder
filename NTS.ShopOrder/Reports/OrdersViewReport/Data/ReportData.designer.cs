﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdersViewReport.Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ShopOrders")]
	public partial class ReportDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertShop(Shop instance);
    partial void UpdateShop(Shop instance);
    partial void DeleteShop(Shop instance);
    #endregion
		
		public ReportDataDataContext() : 
				base(global::OrdersViewReport.Properties.Settings.Default.ShopOrdersConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ReportDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReportDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReportDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ReportDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<vGroup> vGroups
		{
			get
			{
				return this.GetTable<vGroup>();
			}
		}
		
		public System.Data.Linq.Table<vReportOrdersByShop> vReportOrdersByShops
		{
			get
			{
				return this.GetTable<vReportOrdersByShop>();
			}
		}
		
		public System.Data.Linq.Table<Shop> Shops
		{
			get
			{
				return this.GetTable<Shop>();
			}
		}
		
		public System.Data.Linq.Table<vSupplier> vSuppliers
		{
			get
			{
				return this.GetTable<vSupplier>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vGroup")]
	public partial class vGroup
	{
		
		private System.Guid _id;
		
		private int _id_int;
		
		private string _name;
		
		private bool _active;
		
		private string _note;
		
		private string _id_sap;
		
		private System.Nullable<int> _parentId;
		
		private System.Nullable<bool> _check;
		
		public vGroup()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_int", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int id_int
		{
			get
			{
				return this._id_int;
			}
			set
			{
				if ((this._id_int != value))
				{
					this._id_int = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_active", DbType="Bit NOT NULL")]
		public bool active
		{
			get
			{
				return this._active;
			}
			set
			{
				if ((this._active != value))
				{
					this._active = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_note", DbType="VarChar(200)")]
		public string note
		{
			get
			{
				return this._note;
			}
			set
			{
				if ((this._note != value))
				{
					this._note = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_sap", DbType="VarChar(9)")]
		public string id_sap
		{
			get
			{
				return this._id_sap;
			}
			set
			{
				if ((this._id_sap != value))
				{
					this._id_sap = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_parentId", DbType="Int")]
		public System.Nullable<int> parentId
		{
			get
			{
				return this._parentId;
			}
			set
			{
				if ((this._parentId != value))
				{
					this._parentId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[check]", Storage="_check", DbType="Bit")]
		public System.Nullable<bool> check
		{
			get
			{
				return this._check;
			}
			set
			{
				if ((this._check != value))
				{
					this._check = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vReportOrdersByShop")]
	public partial class vReportOrdersByShop
	{
		
		private System.Nullable<System.DateTime> _GoodsDate;
		
		private string _ShopCode;
		
		private string _ShopName;
		
		private string _ShopAddress;
		
		private string _Group;
		
		private string _Name;
		
		private System.Nullable<double> _Quantity;
		
		private System.Nullable<double> _ReqQuantity;
		
		private double _Balance;
		
		private string _Supplier;
		
		private string _Barcode;
		
		private decimal _ShopBalance;
		
		private decimal _ShopSell;
		
		private int _IsReqAssort;
		
		public vReportOrdersByShop()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GoodsDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> GoodsDate
		{
			get
			{
				return this._GoodsDate;
			}
			set
			{
				if ((this._GoodsDate != value))
				{
					this._GoodsDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopCode", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string ShopCode
		{
			get
			{
				return this._ShopCode;
			}
			set
			{
				if ((this._ShopCode != value))
				{
					this._ShopCode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string ShopName
		{
			get
			{
				return this._ShopName;
			}
			set
			{
				if ((this._ShopName != value))
				{
					this._ShopName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopAddress", DbType="NVarChar(255)")]
		public string ShopAddress
		{
			get
			{
				return this._ShopAddress;
			}
			set
			{
				if ((this._ShopAddress != value))
				{
					this._ShopAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Group]", Storage="_Group", DbType="NVarChar(255)")]
		public string Group
		{
			get
			{
				return this._Group;
			}
			set
			{
				if ((this._Group != value))
				{
					this._Group = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Float")]
		public System.Nullable<double> Quantity
		{
			get
			{
				return this._Quantity;
			}
			set
			{
				if ((this._Quantity != value))
				{
					this._Quantity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReqQuantity", DbType="Float")]
		public System.Nullable<double> ReqQuantity
		{
			get
			{
				return this._ReqQuantity;
			}
			set
			{
				if ((this._ReqQuantity != value))
				{
					this._ReqQuantity = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Balance", DbType="Float NOT NULL")]
		public double Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if ((this._Balance != value))
				{
					this._Balance = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Supplier", DbType="NVarChar(255)")]
		public string Supplier
		{
			get
			{
				return this._Supplier;
			}
			set
			{
				if ((this._Supplier != value))
				{
					this._Supplier = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Barcode", DbType="NVarChar(20)")]
		public string Barcode
		{
			get
			{
				return this._Barcode;
			}
			set
			{
				if ((this._Barcode != value))
				{
					this._Barcode = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopBalance", DbType="Decimal(15,3) NOT NULL")]
		public decimal ShopBalance
		{
			get
			{
				return this._ShopBalance;
			}
			set
			{
				if ((this._ShopBalance != value))
				{
					this._ShopBalance = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopSell", DbType="Decimal(15,3) NOT NULL")]
		public decimal ShopSell
		{
			get
			{
				return this._ShopSell;
			}
			set
			{
				if ((this._ShopSell != value))
				{
					this._ShopSell = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsReqAssort", DbType="Int NOT NULL")]
		public int IsReqAssort
		{
			get
			{
				return this._IsReqAssort;
			}
			set
			{
				if ((this._IsReqAssort != value))
				{
					this._IsReqAssort = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Shop")]
	public partial class Shop : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _id;
		
		private string _ShopName;
		
		private string _ShopAddress;
		
		private string _ShopCode;
		
		private System.Nullable<System.Guid> _id_ShopOwner;
		
		private System.Nullable<int> _id_ShopCategory;
		
		private string _id_sap_entity;
		
		private string _id_sap;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(System.Guid value);
    partial void OnidChanged();
    partial void OnShopNameChanging(string value);
    partial void OnShopNameChanged();
    partial void OnShopAddressChanging(string value);
    partial void OnShopAddressChanged();
    partial void OnShopCodeChanging(string value);
    partial void OnShopCodeChanged();
    partial void Onid_ShopOwnerChanging(System.Nullable<System.Guid> value);
    partial void Onid_ShopOwnerChanged();
    partial void Onid_ShopCategoryChanging(System.Nullable<int> value);
    partial void Onid_ShopCategoryChanged();
    partial void Onid_sap_entityChanging(string value);
    partial void Onid_sap_entityChanged();
    partial void Onid_sapChanging(string value);
    partial void Onid_sapChanged();
    #endregion
		
		public Shop()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopName", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string ShopName
		{
			get
			{
				return this._ShopName;
			}
			set
			{
				if ((this._ShopName != value))
				{
					this.OnShopNameChanging(value);
					this.SendPropertyChanging();
					this._ShopName = value;
					this.SendPropertyChanged("ShopName");
					this.OnShopNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopAddress", DbType="NVarChar(255)")]
		public string ShopAddress
		{
			get
			{
				return this._ShopAddress;
			}
			set
			{
				if ((this._ShopAddress != value))
				{
					this.OnShopAddressChanging(value);
					this.SendPropertyChanging();
					this._ShopAddress = value;
					this.SendPropertyChanged("ShopAddress");
					this.OnShopAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShopCode", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string ShopCode
		{
			get
			{
				return this._ShopCode;
			}
			set
			{
				if ((this._ShopCode != value))
				{
					this.OnShopCodeChanging(value);
					this.SendPropertyChanging();
					this._ShopCode = value;
					this.SendPropertyChanged("ShopCode");
					this.OnShopCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_ShopOwner", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> id_ShopOwner
		{
			get
			{
				return this._id_ShopOwner;
			}
			set
			{
				if ((this._id_ShopOwner != value))
				{
					this.Onid_ShopOwnerChanging(value);
					this.SendPropertyChanging();
					this._id_ShopOwner = value;
					this.SendPropertyChanged("id_ShopOwner");
					this.Onid_ShopOwnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_ShopCategory", DbType="Int")]
		public System.Nullable<int> id_ShopCategory
		{
			get
			{
				return this._id_ShopCategory;
			}
			set
			{
				if ((this._id_ShopCategory != value))
				{
					this.Onid_ShopCategoryChanging(value);
					this.SendPropertyChanging();
					this._id_ShopCategory = value;
					this.SendPropertyChanged("id_ShopCategory");
					this.Onid_ShopCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_sap_entity", DbType="NVarChar(10)")]
		public string id_sap_entity
		{
			get
			{
				return this._id_sap_entity;
			}
			set
			{
				if ((this._id_sap_entity != value))
				{
					this.Onid_sap_entityChanging(value);
					this.SendPropertyChanging();
					this._id_sap_entity = value;
					this.SendPropertyChanged("id_sap_entity");
					this.Onid_sap_entityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_sap", DbType="NVarChar(10)")]
		public string id_sap
		{
			get
			{
				return this._id_sap;
			}
			set
			{
				if ((this._id_sap != value))
				{
					this.Onid_sapChanging(value);
					this.SendPropertyChanging();
					this._id_sap = value;
					this.SendPropertyChanged("id_sap");
					this.Onid_sapChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.vSuppliers")]
	public partial class vSupplier
	{
		
		private string _Supplier;
		
		public vSupplier()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Supplier", DbType="NVarChar(255)")]
		public string Supplier
		{
			get
			{
				return this._Supplier;
			}
			set
			{
				if ((this._Supplier != value))
				{
					this._Supplier = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
