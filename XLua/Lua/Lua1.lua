print("First")
--注释

--[[
多行注释
]]

print("****变量****")
--nil  number string boolean
--无需声明类型,赋值时自动识别
a=22
a="22"
a=nil 
print(type(a))
--未声明的变量可以使用,但是是nil

print("****字符串****")
str1='f'
str2="浮"
strleg=#str1+#str2
print("字符串长度为:"..strleg..'个字节')

print(string.format('其中汉字占%d个字节',#str2)) --%d 数字 a all s 字符

tostring(1) --转字符串方法

--字符串的公共方法
str='abcdefG'

print(string.upper(str)..string.lower(str))--大小写转换

print(string.reverse(str))--翻转  输出 Gfedcba

print(string.find(str,"bcd"))--按字查找  输出2	4

print(string.sub(str,3,4))--按位数截取   cd

print(string.rep(str,3))--重复3次字符

print(string.gsub(str,"G",'gh'))--将G替换成gh 输出 abcdefgh	1

print(string.byte("Lua",2))--将u转换为ASCII码

print(string.char(117))--将ASCII码还原为u


print("****运算符****")
--[[
1.有 + - * / ^(幂运算符) 5个基础运算符
2.没有++ --自增自减,也没有符合运算符+=  -=
3.自动识别可转为number的字符串并参与运算
4.条件运算符: < >= == ~=
5.不支持位运算符 || &&和三元运算符? :
]]
print('12.2'+2)--ret:14.2


print("****条件分支语句****")
a=9
if a>5 then --单分支
	print('a比5大'..tostring(a-5))
end

if a<5 then --双分支
	a=0
else
	a=a+1
end

if a<5 then --多分支
--只要是if后面一定不能缺then
elseif a==6 then

elseif a==8	then

elseif a==9 then
else
end
--Lua没有switch


print("****循环语句****")
num=0

while num<5 do--while语句
	str=str..num.." "
    print(str)
	num=num+1
end

repeat --类似do...while循环
	str=str..num.." "
    print(str)
    num=num-1
until num<0--满足条件就跳出循环

for i=1,5,3 do--for循环,i后为初始值,最终值,步长增量
	print(i)
end

local OutLocalValue1='输出脚本返回值1'
local OutLocalValue2='输出脚本返回值2'
local OutLocalValue3='输出脚本返回值3'
OutLocalValues={OutLocalValue1,OutLocalValue2}
return OutLocalValues--多脚本执行:把脚本的局部变量作为脚本输出的返回值才能供其他脚本使用