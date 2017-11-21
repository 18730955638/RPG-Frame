using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
  
public class FileManager{
 
	private FileManager(){

	}

	public static string getStreamingAssets(string fileName){
		string path = Path.Combine(Application.streamingAssetsPath,fileName);  
		FileInfo fileInfo = new FileInfo(path);  
		string s = ""; 
		if (fileInfo.Exists){  
			StreamReader r = new StreamReader(path);  
			//StreamReader默认的是UTF8的不需要转格式了，因为有些中文字符的需要有些是要转的，下面是转成String代码  
			//byte[] data = new byte[1024];  
			// data = Encoding.UTF8.GetBytes(r.ReadToEnd());  
			// s = Encoding.UTF8.GetString(data, 0, data.Length);  
			s = r.ReadToEnd();  
			return s;
		}
		return null;
	}
} 

