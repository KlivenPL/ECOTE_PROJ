class A {
    public:
        unsigned int integer;
        char character;
        bool boolean;
        float floatingPoint;
        long double doubleFloatingPoint;
};

class B {
    public:
        void test(){
            A aObj;
            aObj.integer;
            aObj.character;
            aObj.boolean;
            aObj.floatingPoint;
            aObj.doubleFloatingPoint;
        }
};
