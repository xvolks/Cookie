package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.character.restriction.ActorRestrictionsInformations;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class HumanInformations implements INetworkType
   {
      
      public static const protocolId:uint = 157;
       
      
      public var restrictions:ActorRestrictionsInformations;
      
      public var sex:Boolean = false;
      
      public var options:Vector.<HumanOption>;
      
      private var _restrictionstree:FuncTree;
      
      private var _optionstree:FuncTree;
      
      public function HumanInformations()
      {
         this.restrictions = new ActorRestrictionsInformations();
         this.options = new Vector.<HumanOption>();
         super();
      }
      
      public function getTypeId() : uint
      {
         return 157;
      }
      
      public function initHumanInformations(param1:ActorRestrictionsInformations = null, param2:Boolean = false, param3:Vector.<HumanOption> = null) : HumanInformations
      {
         this.restrictions = param1;
         this.sex = param2;
         this.options = param3;
         return this;
      }
      
      public function reset() : void
      {
         this.restrictions = new ActorRestrictionsInformations();
         this.options = new Vector.<HumanOption>();
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_HumanInformations(param1);
      }
      
      public function serializeAs_HumanInformations(param1:ICustomDataOutput) : void
      {
         this.restrictions.serializeAs_ActorRestrictionsInformations(param1);
         param1.writeBoolean(this.sex);
         param1.writeShort(this.options.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.options.length)
         {
            param1.writeShort((this.options[_loc2_] as HumanOption).getTypeId());
            (this.options[_loc2_] as HumanOption).serialize(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_HumanInformations(param1);
      }
      
      public function deserializeAs_HumanInformations(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:HumanOption = null;
         this.restrictions = new ActorRestrictionsInformations();
         this.restrictions.deserialize(param1);
         this._sexFunc(param1);
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
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_HumanInformations(param1);
      }
      
      public function deserializeAsyncAs_HumanInformations(param1:FuncTree) : void
      {
         this._restrictionstree = param1.addChild(this._restrictionstreeFunc);
         param1.addChild(this._sexFunc);
         this._optionstree = param1.addChild(this._optionstreeFunc);
      }
      
      private function _restrictionstreeFunc(param1:ICustomDataInput) : void
      {
         this.restrictions = new ActorRestrictionsInformations();
         this.restrictions.deserializeAsync(this._restrictionstree);
      }
      
      private function _sexFunc(param1:ICustomDataInput) : void
      {
         this.sex = param1.readBoolean();
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
