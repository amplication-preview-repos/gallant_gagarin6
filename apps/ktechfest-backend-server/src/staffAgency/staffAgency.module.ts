import { Module } from "@nestjs/common";
import { StaffAgencyModuleBase } from "./base/staffAgency.module.base";
import { StaffAgencyService } from "./staffAgency.service";
import { StaffAgencyController } from "./staffAgency.controller";

@Module({
  imports: [StaffAgencyModuleBase],
  controllers: [StaffAgencyController],
  providers: [StaffAgencyService],
  exports: [StaffAgencyService],
})
export class StaffAgencyModule {}
