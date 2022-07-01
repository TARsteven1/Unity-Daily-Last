print("****表的公共操作**********************************************")

table1={{age=1,name="TAR"},{age=2,name="rt"}}
table2={name="ta",sex="male"}
table3={"523","22","098","9878"}

table.insert(table1,table2)--table2插入table1中的尾部
print(table1[3].name)
table.remove(table1,1)--传表进去,默认移除最后一个索引的内容/移除第一个索引内容
print(#table1)
--table.sort(table3)--降序排列
table.sort( table3, function(a,b) --升序排列
if		a>b then
	return true
end
end)
str=table.concat( table3, "",1,2)--拼接:将字符串表从start位置到end位置的所有元素,用""连接拼接成一个字符串,
print(str)


print("****多脚本执行**********************************************")
--只有加local 的变量才是局部变量,否则都是全局变量
--local 的作用域有方法域和脚本域

require('Lua1')--加载其他脚本
print(require('Lua1')[2])--使用其他脚本的变量
print(package.loaded["Lua1"][1])--使用其他脚本的变量,同上

if package.loaded["Lua1"] then
	package.loaded["Lua1"]=nil--卸载已加载的脚本
end

for k,v in pairs(_G) do--遍历_G表(存储我们声明的所有全局变量的总表)
	print(k,v)
end--local变量不会存在_G表中


print("****特殊用法**********************************************")
--多变量赋值 和 多返回值接收,都遵循:多退(扔)少补原则
local a,b=1,2,3
a=2,2

--and or(与 或):可以连接任何东西
--Lua中nil和false 认为是假
--"短路"原则:对于and来说,有假则假;对于or,有真则真,所以他们只判断符号前一个值是否为真就停止运算了
print(0 and 1)--ret:1
print(nil and 1)--ret:nil
print(0 or 1)--ret:0
print(false or 1)--ret:1

local x,y=2,1
local resX3=(x>y)and x or y--实现三元运算符
print(resX3)--ret:2即为x


print("****协程**********************************************")

fun=function ()
	print(a)
end
--创建协程(2种)
print(type(coroutine.create(fun)))--ret:thread; 协程本质是一个线程对象
print(type(coroutine.wrap(fun)))--ret:function;
--执行协程(对应2种)
coroutine.resume(coroutine.create(fun))
coroutine.wrap(fun)()
--挂起
fun2=function (  )
	local i=0
	while true do
		i=i+1
		print("无限循环函数执行了"..i..'次,来自:',coroutine.running())--显示当前运行的协程的线程号

	-- 协程的挂起函数,此函数可以传出值
	coroutine.yield(i,i+1)

	end
end
coroutine.resume(coroutine.create(fun2))--无限循环协程只循环了一次,说明挂起成功
--coroutine.wrap(fun2)()
print(coroutine.resume(coroutine.create(fun2)))--ret:true 1 2  ; 接收协程是否成功运行的bool值和传出的值
print(coroutine.wrap(fun2)())--ret:1 2  ; 接收传出的值
--协程状态:运行中running ,暂停suspended , dead 结束
print("当前协程状态:",coroutine.status(coroutine.create(fun2)))--ret:当前协程状态:	suspended  ;此时的协程已经运行完毕处于暂停状态


print("****元表**********************************************")
--任何表变量都可以作为另一个表变量的元表
--任何表表变量都可以有自己的元表(父表)
--当子表中进行'特定操作'时,也会执行元表中的内容
Meta={
	__tostring=function(v)--__tostring:当子表要被当做字符串使用时,会默认调用元表中的该方法
		return v.name
	end,
	__call = function(a,b,c)--__call:当子表要被当做方法调用时,会默认调用元表中的该方法
		print('ds',a)--调用了自己,也就是打印了MyTable表,也就是执行了__tostring
		print('ds',b)
		print('ds',c)
	end,
	__add=function(t1,t2)--__add:当子表+其他表时,会默认调用元表中的该方法
		return t1.age-t2.age--其他运算符:sub,mul,div,mod(%取余),pow(^幂运算),eq(==),lt(<),le(<=),concat(..拼接)等
	end
}
MyTable={rr="rr",name='TAR',age=22}
OtherTable={age=2}
setmetatable(MyTable,Meta)--设置元表;参数:子表,父表
--特定操作  __tostring
print(MyTable)--ret:TAR
--特定操作  __call
MyTable(2)--第一个参数默认是调用者自己,2实际是第二个参数
--特定操作  __运算符重载
print(MyTable+OtherTable)--ret:20
--特定操作  __index
Meta2Father={age=1}
Meta2Father.__index=Meta2Father
Meta2={}
Meta2.__index=Meta2Father--__index的赋值 写在表外面来初始化
MyTable2={}
setmetatable(MyTable2,Meta2)
setmetatable(Meta2,Meta2Father)
print(MyTable2.age)--当子表中找不到age时,会到每一个父级的__index指向的表中搜索目标
--特定操作  __newindex
MyTable3={}
Meta2.__newindex=Meta2Father--如果子表或自身被赋值一个不存在的索引,则将该索引赋值到指向的表中,而不改变自身
--[[
a.如果__newindex是一个函数，则在给table不存在的字段赋值时，会调用这个函数。
b.如果__newindex是一个table，则在给table不存在的字段赋值时，会直接给__newindex的table赋值。
]]--
MyTable2.name="TAR"--生效条件:自身没有name索引,元表Meta2的__newindex指向了一个第三方表
print(type(getmetatable(MyTable2)))--得到XX的元表
print("在MyTable2中添加新索引,但是却存到了Meta2Father中,说明Meta2.__newindex=Meta2Father生效了;",rawget(Meta2Father,"name"))--ret:TAR;得到XX表的name变量的值,
rawset(MyTable2,"name","tar")--将XX表的name变量改为tar
print(MyTable2.name)--ret:tar
