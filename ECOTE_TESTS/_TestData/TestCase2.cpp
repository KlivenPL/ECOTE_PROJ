class B;

class A {
    public:
        B *b;
        #B *ignored1;
        // B *ignored2;
};

class B {
    public:
        void test(){
            A aObj;
            aObj.b->test();
            //aObj.ignored1->test();
            #aObj.ignored2->test();
        }
};
