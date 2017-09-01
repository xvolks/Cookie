package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.EntityDispositionInformations;
   import com.ankamagames.dofus.network.types.game.look.EntityLook;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class GameRolePlayMerchantInformations extends GameRolePlayNamedActorInformations implements INetworkType
   {
      
      public static const protocolId:uint = 129;
       
      
      public var sellType:uint = 0;
      
      public var options:Vector.<HumanOption>;
      
      private var _optionstree:FuncTree;
      
      public function GameRolePlayMerchantInformations()
      {
         this.options = new Vector.<HumanOption>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 129;
      }
      
      public function initGameRolePlayMerchantInformations(param1:Number = 0, param2:EntityLook = null, param3:EntityDispositionInformations = null, param4:String = "", param5:uint = 0, param6:Vector.<HumanOption> = null) : GameRolePlayMerchantInformations
      {
         super.initGameRolePlayNamedActorInformations(param1,param2,param3,param4);
         this.sellType = param5;
         this.options = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.sellType = 0;
         this.options = new Vector.<HumanOption>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_GameRolePlayMerchantInformations(param1);
      }
      
      public function serializeAs_GameRolePlayMerchantInformations(param1:ICustomDataOutput) : void
      {
         super.serializeAs_GameRolePlayNamedActorInformations(param1);
         if(this.sellType < 0)
         {
            throw new Error("Forbidden value (" + this.sellType + ") on element sellType.");
         }
         param1.writeByte(this.sellType);
         param1.writeShort(this.options.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.options.length)
         {
            param1.writeShort((this.options[_loc2_] as HumanOption).getTypeId());
            (this.options[_loc2_] as HumanOption).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_GameRolePlayMerchantInformations(param1);
      }
      
      public function deserializeAs_GameRolePlayMerchantInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:HumanOption = null;
         super.deserialize(param1);
         this._sellTypeFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(HumanOption,_loc4_);
            _loc5_.deserialize(param1);
            this.options.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_GameRolePlayMerchantInformations(param1);
      }
      
      public function deserializeAsyncAs_GameRolePlayMerchantInformations(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._sellTypeFunc);
         this._optionstree = param1.addChild(this._optionstreeFunc);
      }
      
      private function _sellTypeFunc(param1:ICustomDataInput) : void
      {
         this.sellType = param1.readByte();
         if(this.sellType < 0)
         {
            throw new Error("Forbidden value (" + this.sellType + ") on element of GameRolePlayMerchantInformations.sellType.");
         }
      }
      
      private function _optionstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._optionstree.addChild(this._optionsFunc);
            _loc3_++;
         }
      }
      
      private function _optionsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:HumanOption = ProtocolTypeManager.getInstance(HumanOption,_loc2_);
         _loc3_.deserialize(param1);
         this.options.push(_loc3_);
      }
   }
}
