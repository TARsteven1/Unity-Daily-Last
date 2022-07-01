print("****面向对象**********************************************")
--封装
--面向对象 类 其实都基于table实现
--还有元表知识点
Object={}--万物的基类
Object.id=1

function Object:Test()
	print(self.id)
end

--冒号 是会自动将调用此函数的对象,作为第一个参数传入的
function Object:new()--实例化方法
	--self 代表我们默认传入的第一个参数
	--对象就是变量 返回一个新变量
	--返回出去的内容,本质上就是表对象
	local obj={}
	--元表知识:__index 当自己的变量找不到时,就会去找元表中__index指向的内容
	self.__index=self
	setmetatable(obj,self)
	return obj
end

local myObj=Object:new()
print(myObj,myObj.id)
myObj:Test()
--对空表中 声明一个新的属性 叫id
myObj.id=2



--继承
function Object:subClass(className)--定义一个用于继承的方法
	--_G知识点:总表...
	_G[className]={}
	local obj=_G[className]
	obj.base=self--设置自己的父类
	self.__index=self
	setmetatable(obj,self)
end
Object:subClass('Person')
local p1=Person:new()
print(p1.id)
p1.id=100
print(p1.id)
p1:Test()


--多态:相同的行为不同的表(相同的方法不同的执行逻辑)
Object:subClass("GameObject")
	--成员变量
	GameObject.posX=0
	GameObject.posY=0
	--成员方法
function GameObject:Move()
	self.posX=self.posX+1
	self.posY=self.posY+1
	--print(posX,posY)	
end
--实例化对象使用
local obj=GameObject:new()
obj:Move()
print(obj.posX,obj.posY)

local obj1=GameObject:new()
obj1:Move()
print(obj1.posX,obj1.posY)--ret:1 1  ;说明两个对象obj/1都独立地继承了GameObject

GameObject:subClass("Players")--声明新类继承GameObject
function Players:Move()--多态,重写了GameObject的Move方法
	self.base.Move(self)--base指的是GameObject表(类)
end

local p2=Players:new()
p2:Move()
print(p2.posX,p2.posY)


print("****自带库**********************************************")
--时间
print(os.time())--系统时间
print(os.time({year=2022,month=6,day=26}))--这个函数返回一个值意味着它依赖于你的操作系统，在POSIX ,Windows和一些其他的操作系统上，这个数字是记录了时间原点（1970-01-01）到指点时间的秒数，在个别的系统上结果未定义
for k,v in pairs(os.date("*t")) do
	print(k,v)
end--ret:hour	10--min	12--wday	1--day	26--month	6--year	2022--sec	42--yday	177--isdst	false
print("当前时间 -"..os.date("*t").hour..":"..os.date("*t").min..":"..os.date("*t").sec.."-")

--math函数集
print('绝对值:'..math.abs(-11)..";".."三角函数-传弧度"..math.cos(math.pi))

--路径
print(package.path)--加载路径
package.path=package.path..';C:\\'


print("****GC垃圾回收**********************************************")
print(collectgarbage("count"))--获取当前Lua占用内存数 k字节,用返回值*1024就是具体占用内存字节数
Object=nil--置空就是GC
print(collectgarbage("count"))--ret:比上一次输出少了点,说明GC成功
--Lua也有自动定时进行的GC方法