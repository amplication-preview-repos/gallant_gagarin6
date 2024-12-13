import { Module } from "@nestjs/common";
import { PaymentModuleBase } from "./base/payment.module.base";
import { PaymentService } from "./payment.service";
import { PaymentController } from "./payment.controller";

@Module({
  imports: [PaymentModuleBase],
  controllers: [PaymentController],
  providers: [PaymentService],
  exports: [PaymentService],
})
export class PaymentModule {}
