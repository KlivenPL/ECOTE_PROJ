class A {
	public:
		int a;
		char b;
		
	private:
		void test2(){
			b = 'b';
		}
};

class B {
	public:
		void test(){
			A aObj;
			aObj.a = 2;
			aObj.a = 3;
		}
};
