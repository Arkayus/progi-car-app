public class ReturnDataModel
    {
        public decimal basicFee { get; set; }

        public decimal specialFee { get; set; }

        public decimal associationFee { get; set; }

        public decimal storageFee { get; set; }

        public decimal GetBasicFees(decimal vehiculeBasePrice, VehiculeType vehiculeType) {
            decimal fee = vehiculeBasePrice * 0.10M;

            if(vehiculeType == VehiculeType.Common){
                if(fee < 10){
                    fee = 10.00M;
                } else if(fee > 50){
                    fee = 50.00M;
                }
            } else {
                if(fee < 25){
                    fee = 25.00M;
                } else if(fee > 200){
                    fee = 200.00M;
                }
            }

            return fee;
        }

        public decimal GetSpecialFees(decimal vehiculeBasePrice, VehiculeType vehiculeType) {
            decimal specialFees = 0M;

            if(vehiculeType == VehiculeType.Common){
                specialFees = 0.02M;
            } else {
                specialFees = 0.04M;
            }

            decimal fee = vehiculeBasePrice * specialFees;

            return fee;
        }

        public decimal GetAssociationFees(decimal vehiculeBasePrice) {
            decimal fee = 0;

            if(vehiculeBasePrice >= 1 && vehiculeBasePrice <= 500) {
                fee = 5.00M;
            } else if (vehiculeBasePrice > 500 && vehiculeBasePrice <= 1000) {
                fee = 10.00M;
            } else if (vehiculeBasePrice > 1000 && vehiculeBasePrice <= 3000) {
                fee = 15.00M;
            } else if (vehiculeBasePrice > 3000) {
                fee = 20.00M;
            } 

            return fee;
        }
    }