
--region *.lua
--Date
--此文件由[BabeLua]插件自动生成

--endregion

require "Globo"
require "protobuf.protobuf"
require "Common.functions"
require "Configer.LuaConfig"
require "Frame.FrameBase"

-- 各个功能模块上的脚本　进行实例化


--主入口函数。从这里开始lua逻辑
function Main()					
	print("logic start")	 		
end

--场景切换通知
function OnLevelWasLoaded(level)
	collectgarbage("collect")
	Time.timeSinceLevelLoad = 0
end

function OnApplicationQuit()
end