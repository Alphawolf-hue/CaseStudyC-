using DigitalAssetManagement.dao;
using DigitalAssetManagement.MainModule;
using DigitalAssetManagement.model;
using System;

namespace DigitalAssetManagement.main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AssetManagementMenu menu = new AssetManagementMenu();
            menu.DisplayMenu();
        }
    }
}
