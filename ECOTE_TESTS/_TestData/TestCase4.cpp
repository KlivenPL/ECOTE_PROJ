class B;

class A {
    public:
        B *b;
};

class B {
    public:
        A a;
        void test(){
            A aObj;
            aObj.b->test();
        }
};



class C {
    public:
        void test(){
            A aObj;
            aObj.b->test();
            
            B bObj;
            bObj.a.b = nullptr;
            
        }
};
