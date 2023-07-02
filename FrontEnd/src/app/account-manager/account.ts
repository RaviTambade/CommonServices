export class Account{
  

    constructor(
        public Id :number,
        public Acctnumber :string,
        public Accttype :string,
        public Ifsccode :string,
        public Balance :number,
        public RegisterDate :Date,
        public PeopleId :number
    ){}
}