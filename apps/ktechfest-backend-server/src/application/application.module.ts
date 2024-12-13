import { Module } from "@nestjs/common";
import { ApplicationModuleBase } from "./base/application.module.base";
import { ApplicationService } from "./application.service";
import { ApplicationController } from "./application.controller";

@Module({
  imports: [ApplicationModuleBase],
  controllers: [ApplicationController],
  providers: [ApplicationService],
  exports: [ApplicationService],
})
export class ApplicationModule {}
