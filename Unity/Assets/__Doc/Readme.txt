开发注意事项
1.Hotfix跟HotfixView是纯逻辑的，类中不要带有任何字段，否则热更就会丢失
2.ETTask跟要么调用Coroutine要么就await，打开VS中的错误列表窗口，没有使用这两种的会报出问题，虽然既不await也不Coroutine的话能够编译通过，但是会丢失异常，十分危险
3.请不要使用任何虚函数，用逻辑分发替代
4.请不要使用任何继承，除了继承Entity，用组件替代

Unity.Mono：所有冷更层代码
Unity.Model：热更层的Model，纯数据
Unity.ModelView：热更层的ModelView，涉及到Unity交互的都可以放在这里，例如相机类，UI类等，依旧是纯数据
Unity.Hotfix：对应Unity.Model的纯逻辑
Unity.HotfixView：对应Unity.ModeView的纯逻辑