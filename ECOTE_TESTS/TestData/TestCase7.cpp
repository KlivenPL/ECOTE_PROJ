class A {
    public:
        int test;
};

class B {
    private:
        A aObj;

        void test(){
            aObj.test;
        }
};
