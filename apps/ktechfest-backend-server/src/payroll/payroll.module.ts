import { Module } from "@nestjs/common";
import { PayrollModuleBase } from "./base/payroll.module.base";
import { PayrollService } from "./payroll.service";
import { PayrollController } from "./payroll.controller";

@Module({
  imports: [PayrollModuleBase],
  controllers: [PayrollController],
  providers: [PayrollService],
  exports: [PayrollService],
})
export class PayrollModule {}
