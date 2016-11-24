﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class MEBEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=MEBEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Ils() As DbSet(Of Il)
    Public Overridable Property Ilces() As DbSet(Of Ilce)
    Public Overridable Property Okuls() As DbSet(Of Okul)

    Public Overridable Function GetIlceNo(ilNo As Nullable(Of Integer), ilceNo As Nullable(Of Integer)) As ObjectResult(Of Nullable(Of Integer))
        Dim ilNoParameter As ObjectParameter = If(ilNo.HasValue, New ObjectParameter("IlNo", ilNo), New ObjectParameter("IlNo", GetType(Integer)))

        Dim ilceNoParameter As ObjectParameter = If(ilceNo.HasValue, New ObjectParameter("IlceNo", ilceNo), New ObjectParameter("IlceNo", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Integer))("GetIlceNo", ilNoParameter, ilceNoParameter)
    End Function

    Public Overridable Function GetIlceAd(ilNo As Nullable(Of Integer), ilceNo As Nullable(Of Integer)) As ObjectResult(Of String)
        Dim ilNoParameter As ObjectParameter = If(ilNo.HasValue, New ObjectParameter("IlNo", ilNo), New ObjectParameter("IlNo", GetType(Integer)))

        Dim ilceNoParameter As ObjectParameter = If(ilceNo.HasValue, New ObjectParameter("IlceNo", ilceNo), New ObjectParameter("IlceNo", GetType(Integer)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of String)("GetIlceAd", ilNoParameter, ilceNoParameter)
    End Function

    Public Overridable Function InsertSchool(ilNo As Nullable(Of Integer), ilceNo As Nullable(Of Integer), ad As String, url As String, hakkindaUrl As String) As ObjectResult(Of Nullable(Of Decimal))
        Dim ilNoParameter As ObjectParameter = If(ilNo.HasValue, New ObjectParameter("IlNo", ilNo), New ObjectParameter("IlNo", GetType(Integer)))

        Dim ilceNoParameter As ObjectParameter = If(ilceNo.HasValue, New ObjectParameter("IlceNo", ilceNo), New ObjectParameter("IlceNo", GetType(Integer)))

        Dim adParameter As ObjectParameter = If(ad IsNot Nothing, New ObjectParameter("Ad", ad), New ObjectParameter("Ad", GetType(String)))

        Dim urlParameter As ObjectParameter = If(url IsNot Nothing, New ObjectParameter("Url", url), New ObjectParameter("Url", GetType(String)))

        Dim hakkindaUrlParameter As ObjectParameter = If(hakkindaUrl IsNot Nothing, New ObjectParameter("HakkindaUrl", hakkindaUrl), New ObjectParameter("HakkindaUrl", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of Nullable(Of Decimal))("InsertSchool", ilNoParameter, ilceNoParameter, adParameter, urlParameter, hakkindaUrlParameter)
    End Function

End Class
