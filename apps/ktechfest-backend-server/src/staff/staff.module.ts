import { Module } from "@nestjs/common";
import { StaffModuleBase } from "./base/staff.module.base";
import { StaffService } from "./staff.service";
import { StaffController } from "./staff.controller";

@Module({
  imports: [StaffModuleBase],
  controllers: [StaffController],
  providers: [StaffService],
  exports: [StaffService],
})
export class StaffModule {}
