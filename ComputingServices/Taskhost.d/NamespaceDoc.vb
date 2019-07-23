﻿Namespace TaskHost

    ''' <summary>
    ''' 中央控制将任务所需要调用的函数位置,参数序列化为JSON
    ''' 发送给节点客户端,节点客户端执行分布式计算
    ''' 然后将结果序列化为json返回给中央控制器
    ''' 在这个操作的过程之中,要求函数的参数以及返回值都必须是可以被序列化的
    ''' </summary>
    Module NamespaceDoc

        ' 工作流程
        '
        ' 启动中央控制器服务程序
        ' 节点客户端程序启动,并在中央控制器服务器程序中注册自己的节点
        ' 中央控制器将任务分块,打包函数的执行信息为json
        ' 中央控制器将执行的任务json发送给计算节点客户端
        ' 计算节点客户端反序列化,并执行响应的任务函数
        ' 计算节点将结果打包为json返回至中央控制器
        ' 中央控制器将结果汇总返回给上游调用的函数

    End Module
End Namespace