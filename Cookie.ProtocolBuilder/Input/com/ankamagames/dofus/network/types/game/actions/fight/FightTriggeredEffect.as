package com.ankamagames.dofus.network.types.game.actions.fight
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class FightTriggeredEffect extends AbstractFightDispellableEffect implements INetworkType
   {
      
      public static const protocolId:uint = 210;
       
      
      public var param1:int = 0;
      
      public var param2:int = 0;
      
      public var param3:int = 0;
      
      public var delay:int = 0;
      
      public function FightTriggeredEffect()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 210;
      }
      
      public function initFightTriggeredEffect(param1:uint = 0, param2:Number = 0, param3:int = 0, param4:uint = 1, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:int = 0, param9:int = 0, param10:int = 0, param11:int = 0) : FightTriggeredEffect
      {
         super.initAbstractFightDispellableEffect(param1,param2,param3,param4,param5,param6,param7);
         this.param1 = param8;
         this.param2 = param9;
         this.param3 = param10;
         this.delay = param11;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.param1 = 0;
         this.param2 = 0;
         this.param3 = 0;
         this.delay = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_FightTriggeredEffect(param1);
      }
      
      public function serializeAs_FightTriggeredEffect(param1:ICustomDataOutput) : void
      {
         super.serializeAs_AbstractFightDispellableEffect(param1);
         param1.writeInt(this.param1);
         param1.writeInt(this.param2);
         param1.writeInt(this.param3);
         param1.writeShort(this.delay);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_FightTriggeredEffect(param1);
      }
      
      public function deserializeAs_FightTriggeredEffect(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._param1Func(param1);
         this._param2Func(param1);
         this._param3Func(param1);
         this._delayFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_FightTriggeredEffect(param1);
      }
      
      public function deserializeAsyncAs_FightTriggeredEffect(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._param1Func);
         param1.addChild(this._param2Func);
         param1.addChild(this._param3Func);
         param1.addChild(this._delayFunc);
      }
      
      private function _param1Func(param1:ICustomDataInput) : void
      {
         this.param1 = param1.readInt();
      }
      
      private function _param2Func(param1:ICustomDataInput) : void
      {
         this.param2 = param1.readInt();
      }
      
      private function _param3Func(param1:ICustomDataInput) : void
      {
         this.param3 = param1.readInt();
      }
      
      private function _delayFunc(param1:ICustomDataInput) : void
      {
         this.delay = param1.readShort();
      }
   }
}
