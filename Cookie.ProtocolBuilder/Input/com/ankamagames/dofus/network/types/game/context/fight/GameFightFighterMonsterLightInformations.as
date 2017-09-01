package com.ankamagames.dofus.network.types.game.context.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameFightFighterMonsterLightInformations extends GameFightFighterLightInformations implements INetworkType
   {
      
      public static const protocolId:uint = 455;
       
      
      public var creatureGenericId:uint = 0;
      
      public function GameFightFighterMonsterLightInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 455;
      }
      
      public function initGameFightFighterMonsterLightInformations(param1:Number = 0, param2:uint = 0, param3:uint = 0, param4:int = 0, param5:Boolean = false, param6:Boolean = false, param7:uint = 0) : GameFightFighterMonsterLightInformations
      {
         super.initGameFightFighterLightInformations(param1,param2,param3,param4,param5,param6);
         this.creatureGenericId = param7;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.creatureGenericId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameFightFighterMonsterLightInformations(param1);
      }
      
      public function serializeAs_GameFightFighterMonsterLightInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameFightFighterLightInformations(param1);
         if(this.creatureGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.creatureGenericId + ") on element creatureGenericId.");
         }
         param1.writeVarShort(this.creatureGenericId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameFightFighterMonsterLightInformations(param1);
      }
      
      public function deserializeAs_GameFightFighterMonsterLightInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._creatureGenericIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameFightFighterMonsterLightInformations(param1);
      }
      
      public function deserializeAsyncAs_GameFightFighterMonsterLightInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._creatureGenericIdFunc);
      }
      
      private function _creatureGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.creatureGenericId = param1.readVarUhShort();
         if(this.creatureGenericId < 0)
         {
            throw new Error("Forbidden value (" + this.creatureGenericId + ") on element of GameFightFighterMonsterLightInformations.creatureGenericId.");
         }
      }
   }
}
