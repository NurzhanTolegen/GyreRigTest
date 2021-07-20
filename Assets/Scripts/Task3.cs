interface ISomeInterface3 {
    void Call();
}
struct SomeStruct3 : ISomeInterface3 {
    public float num;
    public void Call() { }
}
class SomeClass3 {
    public void Run() {
        var someStruct = new SomeStruct3();
        object someStructObj = someStruct;
        SomeMethod(someStructObj);
    }
    public void SomeMethod(object @interface) {
        ((ISomeInterface3)@interface).Call();
    }
}