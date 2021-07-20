namespace Variant1 {
    public struct ApiSetup<T> {
        public T obj;
        public ApiSetup(T obj) {
            this.obj = obj;
        }
    }
    class Api {
        public ApiSetup<T> For<T>(T obj) {
            return new ApiSetup<T>();
        }
    }
    interface ISomeInterfaceA { }
    interface ISomeInterfaceB { }
    public class ObjectA : ISomeInterfaceA {
        public void SetupObjectA() { }
    }
    public class ObjectB : ISomeInterfaceB {
        public void SetupObjectB() { }
    }
    class SomeClass {
        public void Setup() {
            Api apiObject = new Api();

            apiObject.For(new ObjectA()).obj.SetupObjectA();
            apiObject.For(new ObjectB()).obj.SetupObjectB();
        }
    }
}


namespace Variant2 {
    public struct ApiSetupA {
        public void SetupObjectA() { }
    }
    public struct ApiSetupB {
        public void SetupObjectB() { }
    }
    class Api {
        public ApiSetupA For(ObjectA obj) {
            return new ApiSetupA();
        }
        public ApiSetupB For(ObjectB obj) {
            return new ApiSetupB();
        }
    }
    interface ISomeInterface { }
    interface ISomeInterfaceA : ISomeInterface { }
    interface ISomeInterfaceB : ISomeInterface { }
    public class ObjectA : ISomeInterfaceA {
    }
    public class ObjectB : ISomeInterfaceB {
    }
    class SomeClass {
        public void Setup() {
            Api apiObject = new Api();

            apiObject.For(new ObjectA()).SetupObjectA();
            apiObject.For(new ObjectB()).SetupObjectB();
        }
    }
}