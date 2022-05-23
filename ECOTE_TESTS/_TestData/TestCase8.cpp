class A {
    public:
        int test = 1;
        bool test2 = false;
        char test3;
        char test4 = 'k';
};

class B {
    private:
        A aObj;
        void test(){
            test2(aObj.test, aObj.test2);
            aObj.test3 = aObj.test4;
        }
        
        void test2(int a, bool b){
            
        }
};
