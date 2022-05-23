class B;

class A {
    public:
        B *b;
};

class B {
    public:
        void test(){
            A aObj;
            aObj.b->test();
        }
};
