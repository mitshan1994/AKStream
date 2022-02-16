﻿using System;
using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace LibLogger
{
    public static class Logger
    {
        private static readonly ILog _instance = null;
        public static bool init = true;
        private static object lockobj = new object();
        public static string logxmlPath = Environment.CurrentDirectory + "/Config/";

        static Logger()
        {
            lock (lockobj)
            {
                ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
                
                XmlConfigurator.Configure(repository,
                    new FileInfo(logxmlPath+"logconfig.xml")); //程序启动目录下
                _instance = LogManager.GetLogger(repository.Name, "AKStream");
            }
        }


        public static void Info(string msg)
        {
            _instance.Info(msg);
        }

        public static void Debug(string msg)
        {
            _instance.Debug(msg);
        }

        public static void Error(string msg)
        {
            _instance.Error(msg);
        }

        public static void Warn(string msg)
        {
            _instance.Warn(msg);
        }

        public static void Fatal(string msg)
        {
            _instance.Fatal(msg);
        }

       

        /// <summary>
        /// 获取日志级别
        /// </summary>
        /// <returns></returns>
        public static string GetLogLevel()
        {
           return ((Hierarchy) LogManager.GetRepository()).Root.Level.ToString();
        }
    }
}