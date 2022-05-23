class A {
    public:
        int test;
        bool test2;
};

class B {
    private:
        A aObj;
        void test(){
            test2(aObj.test, aObj.test2);
        }
        
        void test2(int a, bool b){
            
        }
};
