﻿
--声明，这里声明了类名还有属性，并且给出了属性的初始值。
LuaClass = {}

local this = LuaClass;

--这句是重定义元表的索引，就是说有了这句，这个才是一个类。
LuaClass.__index = LuaClass ;

--构造体，构造体的名字是随便起的，习惯性改为New()
function LuaClass:New() 
    local self = {};    --初始化self，如果没有这句，那么类所建立的对象改变，其他对象都会改变
    setmetatable(self, LuaClass);  --将self的元表设定为Class
   
    return self;    --返回自身
end

function LuaClass:SetObj(obj)
    this.gameObj = obj;
end

-- 编写控制逻辑