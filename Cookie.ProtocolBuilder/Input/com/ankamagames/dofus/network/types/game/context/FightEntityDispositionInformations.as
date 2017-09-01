package com.ankamagames.dofus.network.types.game.context
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class FightEntityDispositionInformations extends EntityDispositionInformations implements INetworkType
   {
      
      public static const protocolId:uint = 217;
       
      
      public var carryingCharacterId:Number = 0;
      
      public function FightEntityDispositionInformations()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 217;
      }
      
      public function initFightEntityDispositionInformations(param1:int = 0, param2:uint = 1, param3:Number = 0) : FightEntityDispositionInformations
      {
         super.initEntityDispositionInformations(param1,param2);
         this.carryingCharacterId = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.carryingCharacterId = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightEntityDispositionInformations(param1);
      }
      
      public function serializeAs_FightEntityDispositionInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_EntityDispositionInformations(param1);
         if(this.carryingCharacterId < -9007199254740990 || this.carryingCharacterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.carryingCharacterId + ") on element carryingCharacterId.");
         }
         param1.writeDouble(this.carryingCharacterId);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightEntityDispositionInformations(param1);
      }
      
      public function deserializeAs_FightEntityDispositionInformations(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._carryingCharacterIdFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightEntityDispositionInformations(param1);
      }
      
      public function deserializeAsyncAs_FightEntityDispositionInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._carryingCharacterIdFunc);
      }
      
      private function _carryingCharacterIdFunc(param1:ICustomDataInput) : void
      {
         this.carryingCharacterId = param1.readDouble();
         if(this.carryingCharacterId < -9007199254740990 || this.carryingCharacterId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.carryingCharacterId + ") on element of FightEntityDispositionInformations.carryingCharacterId.");
         }
      }
   }
}
