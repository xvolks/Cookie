package com.ankamagames.dofus.network.types.game.data.items.effects
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class ObjectEffectLadder extends ObjectEffectCreature implements INetworkType
   {
      
      public static const protocolId:uint = 81;
       
      
      public var monsterCount:uint = 0;
      
      public function ObjectEffectLadder()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 81;
      }
      
      public function initObjectEffectLadder(param1:uint = 0, param2:uint = 0, param3:uint = 0) : ObjectEffectLadder
      {
         super.initObjectEffectCreature(param1,param2);
         this.monsterCount = param3;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.monsterCount = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectEffectLadder(param1);
      }
      
      public function serializeAs_ObjectEffectLadder(param1:ICustomDataOutput) : void
      {
         super.serializeAs_ObjectEffectCreature(param1);
         if(this.monsterCount < 0)
         {
            throw new Error("Forbidden value (" + this.monsterCount + ") on element monsterCount.");
         }
         param1.writeVarInt(this.monsterCount);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectEffectLadder(param1);
      }
      
      public function deserializeAs_ObjectEffectLadder(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._monsterCountFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectEffectLadder(param1);
      }
      
      public function deserializeAsyncAs_ObjectEffectLadder(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._monsterCountFunc);
      }
      
      private function _monsterCountFunc(param1:ICustomDataInput) : void
      {
         this.monsterCount = param1.readVarUhInt();
         if(this.monsterCount < 0)
         {
            throw new Error("Forbidden value (" + this.monsterCount + ") on element of ObjectEffectLadder.monsterCount.");
         }
      }
   }
}
