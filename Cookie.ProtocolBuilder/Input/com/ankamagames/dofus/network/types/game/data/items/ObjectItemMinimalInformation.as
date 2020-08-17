package com.ankamagames.dofus.network.types.game.data.items
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.data.items.effects.ObjectEffect;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class ObjectItemMinimalInformation extends Item implements INetworkType
   {
      
      public static const protocolId:uint = 124;
       
      
      public var objectGID:uint = 0;
      
      public var effects:Vector.<ObjectEffect>;
      
      private var _effectstree:FuncTree;
      
      public function ObjectItemMinimalInformation()
      {
         this.effects = new Vector.<ObjectEffect>();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 124;
      }
      
      public function initObjectItemMinimalInformation(param1:uint = 0, param2:Vector.<ObjectEffect> = null) : ObjectItemMinimalInformation
      {
         this.objectGID = param1;
         this.effects = param2;
         return this;
      }
      
      override public function reset() : void
      {
         this.objectGID = 0;
         this.effects = new Vector.<ObjectEffect>();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_ObjectItemMinimalInformation(param1);
      }
      
      public function serializeAs_ObjectItemMinimalInformation(param1:ICustomDataOutput) : void
      {
         super.serializeAs_Item(param1);
         if(this.objectGID < 0)
         {
            throw new Error("Forbidden value (" + this.objectGID + ") on element objectGID.");
         }
         param1.writeVarShort(this.objectGID);
         param1.writeShort(this.effects.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.effects.length)
         {
            param1.writeShort((this.effects[_loc2_] as ObjectEffect).getTypeId());
            (this.effects[_loc2_] as ObjectEffect).serialize(param1);
            _loc2_++;
         }
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_ObjectItemMinimalInformation(param1);
      }
      
      public function deserializeAs_ObjectItemMinimalInformation(param1:ICustomDataInput) : void
      {
         var _loc4_:uint = 0;
         var _loc5_:ObjectEffect = null;
         super.deserialize(param1);
         this._objectGIDFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = param1.readUnsignedShort();
            _loc5_ = ProtocolTypeManager.getInstance(ObjectEffect,_loc4_);
            _loc5_.deserialize(param1);
            this.effects.push(_loc5_);
            _loc3_++;
         }
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_ObjectItemMinimalInformation(param1);
      }
      
      public function deserializeAsyncAs_ObjectItemMinimalInformation(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._objectGIDFunc);
         this._effectstree = param1.addChild(this._effectstreeFunc);
      }
      
      private function _objectGIDFunc(param1:ICustomDataInput) : void
      {
         this.objectGID = param1.readVarUhShort();
         if(this.objectGID < 0)
         {
            throw new Error("Forbidden value (" + this.objectGID + ") on element of ObjectItemMinimalInformation.objectGID.");
         }
      }
      
      private function _effectstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._effectstree.addChild(this._effectsFunc);
            _loc3_++;
         }
      }
      
      private function _effectsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:ObjectEffect = ProtocolTypeManager.getInstance(ObjectEffect,_loc2_);
         _loc3_.deserialize(param1);
         this.effects.push(_loc3_);
      }
   }
}
