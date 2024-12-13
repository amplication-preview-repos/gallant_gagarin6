import { Module } from "@nestjs/common";
import { RatingModuleBase } from "./base/rating.module.base";
import { RatingService } from "./rating.service";
import { RatingController } from "./rating.controller";

@Module({
  imports: [RatingModuleBase],
  controllers: [RatingController],
  providers: [RatingService],
  exports: [RatingService],
})
export class RatingModule {}
