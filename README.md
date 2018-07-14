<<<<<<< HEAD
# School
校园信息统计平台
=======
﻿                                                                                                       	校园信息管理系统

功能说明：
学生信息管理，包括学生、班级、院系、课程、成绩等的管理。

 工程环境:
* [JDK10.01]
* [Myeclipse 2017 C1]
* [MySQL]

运行说明:

1. 本程序是Runable JAR文件，需安装JRE才可运行。  
2. 本程序使用MySQL数据库，使用前请导入[DumpStructureOnly.sql](database/DumpStructureOnly.sql)（数据库结构文件）
或者[DumpStructure_and_Data.sql](database/DumpStructure_and_Data.sql)（带有测试数据的数据库文件）进MySQL，并设置如下（可在`dbConn.java`修改）：
    * 数据库端口：8080
    * 数据库名：TellHubaDB
    * 数据库用户名：root
    * 数据库密码：123
3. 满足以上条件下运行`stuManager.jar`则可以运行系统。

登录说明：
1. 打开本程序首先进入登录界面，有账号可直接登录，无账号点击注册进行注册登陆。  
**注意**：注册，默认注册普通用户（`userType = 2`），普通用户无添加用户、删除用户功能；
   要添加管理员账号（`userType = 1`）只能在数据库添加。
2. `DumpStructure_and_Data.sql`数据库的`tb_user`表中有学生系统管理员账号：`admin`，密码为空，可以用其登录测试。
>>>>>>> first commit
