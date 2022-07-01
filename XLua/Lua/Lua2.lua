print("****函数方法****")
--形式参考C#的委托
function F1()--不支持重,载方法默认调用会后一个
	 print(a)
end


function F1(a)--重载F1方法,声明形参 a
	return type(a),a,'占位参数' --返回值可以有多个
end
fun1=F1


function F2(...)--变长参数,用表存储形参列表,当然也可以直接用俩形参代替
	agr={...}--实例化一个表
	if agr[1]=="number" or agr[3]== '占位参数'  then --Lua的数字是从1开始
	return print(agr[2]..'是数字') --返回值
    else
	return print(agr[2]..'不是数字')
    end
end

F2(F1(2))--调用方法

function F3(x)

	return function(y)--嵌套函数
	print(x.." "..y )
		return x+y
	end
end

F4=F3(1)
print(F4(5))--闭包(改变传入参数生命周期)


print("****复杂数据类型 table**********************************************")
--所有复杂类型都是表

print("****数组**********************************************")
array={1,2,"22",true,nil}--用表构建数组
print(array[1],#array)--调用数组首位元素;#是通用的获取长度的字符,#打印长度会忽略空格,表中某一位是nil,会影响#输出的长度
for i=1,#array do--遍历数组
	print(array[i])
end

arrays={{1,2,3},{4,6,6}}--用表构建二维数组
print(arrays[1][2])--输出二维数组
for i=1,#arrays do--遍历二维数组
temp=arrays[i]
for j=1,#temp do
	print(temp[j])
end
end

array={[0]=1,2,3,[-1]=5,7,[6]=9}--自定义索引,让表可以有第0位
print(#array)
for i=1,#array do--遍历数组输出237,说明小于1的位数的元素不会被#遍历输出,大于等于2位空缺后的元素也不会
	print(array[i])
end


print("****迭代器(遍历)**********************************************")
--用#遍历表有所局限,所以推荐用迭代器
for i,k in ipairs(array) do--ipairs跟#差不多垃圾,但有键值对的概念
	print("ipairs迭代器遍历结果:"..i.."_"..k)
end

for i,k in pairs(array) do--pairs能找到所有键值,但小于1的键值顺序诡异
	print("pairs迭代器遍历结果:"..i.."_"..k)
end


print("****字典**********************************************")
dictionary={["name"]="TAR",["age"]=22,["sex"]="male"}
dictionary.age=23--修改
dictionary["state"]="hh"--增
dictionary.age=nil--删

for _,v in pairs(dictionary) do--字典遍历必用pairs
	print("pairs迭代器遍历结果:".._.."_"..v)
end


print("****类&结构体**********************************************")
--Lua中默认没有面向对象的
Student={--声明一个类
	age=1,
	sex="male",
	Study=function(t)
		print("studying"..t.age.."年了")
	end,
	Up=function(t)
		print("我是个"..t.age.."岁的"..Student.sex)--调用自身参数的两种形式
	end	
}
--在表外声明变量和方法
Student.name="zz"
Student.Speak=function()
	print('Speak English')
end
--声明方法,方式3
function Student.Speak2()
	print('Speak Japenises')
end

Student.Up(Student)--调用自己
Student:Study()--效果同上,使用冒号:会默认把调用者,作为第一个参数传入方法中

return fun1