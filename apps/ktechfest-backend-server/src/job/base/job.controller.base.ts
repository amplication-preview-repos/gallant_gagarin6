/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { isRecordNotFoundError } from "../../prisma.util";
import * as errors from "../../errors";
import { Request } from "express";
import { plainToClass } from "class-transformer";
import { ApiNestedQuery } from "../../decorators/api-nested-query.decorator";
import { JobService } from "../job.service";
import { JobCreateInput } from "./JobCreateInput";
import { Job } from "./Job";
import { JobFindManyArgs } from "./JobFindManyArgs";
import { JobWhereUniqueInput } from "./JobWhereUniqueInput";
import { JobUpdateInput } from "./JobUpdateInput";
import { ApplicationFindManyArgs } from "../../application/base/ApplicationFindManyArgs";
import { Application } from "../../application/base/Application";
import { ApplicationWhereUniqueInput } from "../../application/base/ApplicationWhereUniqueInput";
import { RatingFindManyArgs } from "../../rating/base/RatingFindManyArgs";
import { Rating } from "../../rating/base/Rating";
import { RatingWhereUniqueInput } from "../../rating/base/RatingWhereUniqueInput";
import { SkillFindManyArgs } from "../../skill/base/SkillFindManyArgs";
import { Skill } from "../../skill/base/Skill";
import { SkillWhereUniqueInput } from "../../skill/base/SkillWhereUniqueInput";

export class JobControllerBase {
  constructor(protected readonly service: JobService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: Job })
  @swagger.ApiBody({
    type: JobCreateInput,
  })
  async createJob(@common.Body() data: JobCreateInput): Promise<Job> {
    return await this.service.createJob({
      data: {
        ...data,

        assignedTo: data.assignedTo
          ? {
              connect: data.assignedTo,
            }
          : undefined,

        associatedAgency: data.associatedAgency
          ? {
              connect: data.associatedAgency,
            }
          : undefined,

        payments: data.payments
          ? {
              connect: data.payments,
            }
          : undefined,

        user: data.user
          ? {
              connect: data.user,
            }
          : undefined,
      },
      select: {
        assignedTo: {
          select: {
            id: true,
          },
        },

        associatedAgency: {
          select: {
            id: true,
          },
        },

        availability: true,
        completed: true,
        createdAt: true,
        cv: true,
        description: true,
        duration: true,
        id: true,
        isAcceptedByAgency: true,
        isPaid: true,
        payRate: true,

        payments: {
          select: {
            id: true,
          },
        },

        status: true,
        title: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [Job] })
  @ApiNestedQuery(JobFindManyArgs)
  async jobs(@common.Req() request: Request): Promise<Job[]> {
    const args = plainToClass(JobFindManyArgs, request.query);
    return this.service.jobs({
      ...args,
      select: {
        assignedTo: {
          select: {
            id: true,
          },
        },

        associatedAgency: {
          select: {
            id: true,
          },
        },

        availability: true,
        completed: true,
        createdAt: true,
        cv: true,
        description: true,
        duration: true,
        id: true,
        isAcceptedByAgency: true,
        isPaid: true,
        payRate: true,

        payments: {
          select: {
            id: true,
          },
        },

        status: true,
        title: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: Job })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async job(@common.Param() params: JobWhereUniqueInput): Promise<Job | null> {
    const result = await this.service.job({
      where: params,
      select: {
        assignedTo: {
          select: {
            id: true,
          },
        },

        associatedAgency: {
          select: {
            id: true,
          },
        },

        availability: true,
        completed: true,
        createdAt: true,
        cv: true,
        description: true,
        duration: true,
        id: true,
        isAcceptedByAgency: true,
        isPaid: true,
        payRate: true,

        payments: {
          select: {
            id: true,
          },
        },

        status: true,
        title: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: Job })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @swagger.ApiBody({
    type: JobUpdateInput,
  })
  async updateJob(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() data: JobUpdateInput
  ): Promise<Job | null> {
    try {
      return await this.service.updateJob({
        where: params,
        data: {
          ...data,

          assignedTo: data.assignedTo
            ? {
                connect: data.assignedTo,
              }
            : undefined,

          associatedAgency: data.associatedAgency
            ? {
                connect: data.associatedAgency,
              }
            : undefined,

          payments: data.payments
            ? {
                connect: data.payments,
              }
            : undefined,

          user: data.user
            ? {
                connect: data.user,
              }
            : undefined,
        },
        select: {
          assignedTo: {
            select: {
              id: true,
            },
          },

          associatedAgency: {
            select: {
              id: true,
            },
          },

          availability: true,
          completed: true,
          createdAt: true,
          cv: true,
          description: true,
          duration: true,
          id: true,
          isAcceptedByAgency: true,
          isPaid: true,
          payRate: true,

          payments: {
            select: {
              id: true,
            },
          },

          status: true,
          title: true,
          updatedAt: true,

          user: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Delete("/:id")
  @swagger.ApiOkResponse({ type: Job })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteJob(
    @common.Param() params: JobWhereUniqueInput
  ): Promise<Job | null> {
    try {
      return await this.service.deleteJob({
        where: params,
        select: {
          assignedTo: {
            select: {
              id: true,
            },
          },

          associatedAgency: {
            select: {
              id: true,
            },
          },

          availability: true,
          completed: true,
          createdAt: true,
          cv: true,
          description: true,
          duration: true,
          id: true,
          isAcceptedByAgency: true,
          isPaid: true,
          payRate: true,

          payments: {
            select: {
              id: true,
            },
          },

          status: true,
          title: true,
          updatedAt: true,

          user: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Get("/:id/applications")
  @ApiNestedQuery(ApplicationFindManyArgs)
  async findApplications(
    @common.Req() request: Request,
    @common.Param() params: JobWhereUniqueInput
  ): Promise<Application[]> {
    const query = plainToClass(ApplicationFindManyArgs, request.query);
    const results = await this.service.findApplications(params.id, {
      ...query,
      select: {
        createdAt: true,
        id: true,

        job: {
          select: {
            id: true,
          },
        },

        staffAgency: {
          select: {
            id: true,
          },
        },

        status: true,
        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/applications")
  async connectApplications(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: ApplicationWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      applications: {
        connect: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/applications")
  async updateApplications(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: ApplicationWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      applications: {
        set: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/applications")
  async disconnectApplications(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: ApplicationWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      applications: {
        disconnect: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/ratings")
  @ApiNestedQuery(RatingFindManyArgs)
  async findRatings(
    @common.Req() request: Request,
    @common.Param() params: JobWhereUniqueInput
  ): Promise<Rating[]> {
    const query = plainToClass(RatingFindManyArgs, request.query);
    const results = await this.service.findRatings(params.id, {
      ...query,
      select: {
        comment: true,
        createdAt: true,

        entityRated: {
          select: {
            id: true,
          },
        },

        id: true,

        job: {
          select: {
            id: true,
          },
        },

        ratedBy: {
          select: {
            id: true,
          },
        },

        ratingValue: true,
        updatedAt: true,
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/ratings")
  async connectRatings(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: RatingWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      ratings: {
        connect: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/ratings")
  async updateRatings(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: RatingWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      ratings: {
        set: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/ratings")
  async disconnectRatings(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: RatingWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      ratings: {
        disconnect: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/requiredSkills")
  @ApiNestedQuery(SkillFindManyArgs)
  async findRequiredSkills(
    @common.Req() request: Request,
    @common.Param() params: JobWhereUniqueInput
  ): Promise<Skill[]> {
    const query = plainToClass(SkillFindManyArgs, request.query);
    const results = await this.service.findRequiredSkills(params.id, {
      ...query,
      select: {
        createdAt: true,
        description: true,
        id: true,

        jobs: {
          select: {
            id: true,
          },
        },

        name: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/requiredSkills")
  async connectRequiredSkills(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      requiredSkills: {
        connect: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/requiredSkills")
  async updateRequiredSkills(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      requiredSkills: {
        set: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/requiredSkills")
  async disconnectRequiredSkills(
    @common.Param() params: JobWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      requiredSkills: {
        disconnect: body,
      },
    };
    await this.service.updateJob({
      where: params,
      data,
      select: { id: true },
    });
  }
}
